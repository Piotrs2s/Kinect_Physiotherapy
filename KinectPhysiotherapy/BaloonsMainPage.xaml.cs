using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;


namespace KinectPhysiotherapy
{
    /// <summary>
    /// Interaction logic for BaloonsMainPage.xaml
    /// </summary>
    public partial class BaloonsMainPage : Page
    {
        //Generator of floating baloons
        public BaloonsGenerator Generator;

        KinectSensor _sensor;
        MultiSourceFrameReader _reader;

        Body[] bodies; 
        bool _displayBody = false;



        public BaloonsMainPage(int frequency, int speed)
        {
            InitializeComponent();
            Generator = new BaloonsGenerator(baloonCanvas, frequency, speed); //frequency and speed of baloons (ticks to next baloon and  length of timer tick) 
        }

        //Start recording button
        private void StartRecording(object sender, RoutedEventArgs e)
        {
            _sensor = KinectSensor.GetDefault();

            //Start generating baloons
            Generator.Start();

            if (_sensor != null)
            {
                _sensor.Open();

                bodies = new Body[6]; 
                _reader = _sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color | FrameSourceTypes.Body);

                _reader.MultiSourceFrameArrived += Reader_MultiSourceFrameArrived;

                _displayBody = !_displayBody;
            }
        }

        private void Reader_MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
        {
            // Get a reference to the multi-frame
            var reference = e.FrameReference.AcquireFrame();
          
            using (BodyFrame bodyFrame = reference.BodyFrameReference.AcquireFrame())
            {
          
                // Open color frame
                using (var frame = reference.ColorFrameReference.AcquireFrame())
                {
                    if (frame != null && bodyFrame != null)
                    {
                        camera.Source = ToBitmap(frame);

                        bodyFrame.GetAndRefreshBodyData(bodies);
                      //  imgCanvas.Children.Clear();

                        bodyCanvas.Children.Clear();

       

                        foreach (var body in bodies)
                        {
                            if (body.IsTracked)
                            {
                              
                                //Hands joints
                                Joint jointHandLeft = body.Joints[JointType.HandLeft];
                                Joint jointHandRight = body.Joints[JointType.HandRight];

                               

                                // Textboxes for statistics
                                textBox_baloonsHitted.Text = "Hitted: " + Generator.baloonsHitted;
                                textBox_baloonsFloated.Text = "Floated: " + Generator.baloonsFloated;
                                textBoxHandPosition.Text = String.Format("{0:N2}", jointHandLeft.Position.X) + " : " + String.Format("{0:N2}", jointHandLeft.Position.Y);
                                if (Generator.baloonsFloated > 0)
                                {
                                    double percent = Generator.baloonsHitted * 100 / Generator.baloonsFloated;
                                    textBox_percent.Text = percent + "%";
                                }
                                
                               
                                for (int i = Generator.BaloonsList.Count - 1; i >= 0; i--)
                                {
                                    ////Shows position of last baloon
                                    textBoxBaloonPosition.Text = CoordinatesConverter.convertX(baloonCanvas, Canvas.GetLeft(Generator.BaloonsList[i])) + " : "
                                        + CoordinatesConverter.convertY(baloonCanvas, Canvas.GetBottom(Generator.BaloonsList[i]));

                                    //Check if ballon is caughted 
                                    if (Generator.BaloonIsCaught(jointHandLeft, jointHandRight, Generator.BaloonsList[i]))
                                    {

                                        //Check if baloon is already caughted (so it wont count baloon as catched during explosion animation)
                                        if (Generator.BaloonsList[i].AllowDrop == false)
                                        {
                                            //Mark baloon as already caughted
                                            Generator.BaloonsList[i].AllowDrop = true;
                                            //Destroy baloon
                                            Generator.DestroyBaloon(Generator.BaloonsList[i]);
                                        }
                                    }


                                }


                              
                              
                                jointHandLeft = SkeletonDrawing.ScaleTo(jointHandLeft, bodyCanvas.Width, bodyCanvas.Height);

                               
                                   // DepthSpacePoint dsp = _sensor.CoordinateMapper.MapCameraPointToDepthSpace(jointHandLeft.Position);

                                    var testJointEllipse = new Ellipse() { Height = 10, Width = 10, Fill = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0)) };

                                    bodyCanvas.Children.Add(testJointEllipse);

                                    Canvas.SetLeft(testJointEllipse, jointHandLeft.Position.X);
                                    Canvas.SetTop(testJointEllipse, jointHandLeft.Position.Y);
                               
                                

                                #region SkeletonDrawing
                                //SkeletonDrawing.DrawPoint(JointType.HandLeft, body, _sensor, bodyCanvas);
                                //SkeletonDrawing.DrawPoint(JointType.HandRight, body, _sensor, bodyCanvas);

                                //SkeletonDrawing.DrawLine(JointType.HandLeft, JointType.HandRight, body, bodyCanvas);
                                //SkeletonDrawing.DrawSceleton(body, bodyCanvas);

                                #endregion
                            }


                        }
                      


                    }
                }
            }



           
        }

        private ImageSource ToBitmap(ColorFrame frame)
        {
            int width = frame.FrameDescription.Width;
            int height = frame.FrameDescription.Height;


            PixelFormat format = PixelFormats.Bgr32;

            byte[] pixels = new byte[width * height * ((PixelFormats.Bgr32.BitsPerPixel + 7) / 8)];

            if (frame.RawColorImageFormat == ColorImageFormat.Bgra)
            {
                frame.CopyRawFrameDataToArray(pixels);
            }
            else
            {
                frame.CopyConvertedFrameDataToArray(pixels, ColorImageFormat.Bgra);
            }

            int stride = width * format.BitsPerPixel / 8;

            return BitmapSource.Create(width, height, 96, 96, format, null, pixels, stride);
        }

      


    }
}
