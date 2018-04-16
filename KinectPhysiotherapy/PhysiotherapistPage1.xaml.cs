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

    public partial class PhysiotherapistPage1 : Page
    {
        // BaloonsGenerator Generator;
        public BaloonsGenerator Generator;
        int HittedBaloonsCounter;

        KinectSensor _sensor;
        MultiSourceFrameReader _reader;



        //IList<Body> _bodies; // body ver 1
        Body[] bodies; //body ver 2
        bool _displayBody = false;

      

        public PhysiotherapistPage1()
        {
            InitializeComponent();
            Generator = new BaloonsGenerator(baloonCanvas, 300, 60);
            HittedBaloonsCounter = 0;

        }

        //Start recording button
        private void StartRecording(object sender, RoutedEventArgs e)
        {
            _sensor = KinectSensor.GetDefault();

            Generator.Start();

            if (_sensor != null)
            {
                _sensor.Open();

                bodies = new Body[6]; //Body ver 2
                _reader = _sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color | FrameSourceTypes.Body);


               


                _reader.MultiSourceFrameArrived += Reader_MultiSourceFrameArrived;

                _displayBody = !_displayBody;
            }
        }

        private void Reader_MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
        {
            // Get a reference to the multi-frame
            var reference = e.FrameReference.AcquireFrame();
            //Body ver 2 reference
            //var bodyFrame = reference.BodyFrameReference.AcquireFrame();

            
            

            using (BodyFrame bodyFrame = reference.BodyFrameReference.AcquireFrame())
            {
                // Open color frame
                using (var frame = reference.ColorFrameReference.AcquireFrame())
                {
                    if (frame != null && bodyFrame != null)
                    { 
                        camera.Source = ToBitmap(frame);

                        //Body ver 2
                        bodyFrame.GetAndRefreshBodyData(bodies);
                        imgCanvas.Children.Clear();
                        #region BodyDrawing
                        //BODY DRAWING
                        foreach (var body in bodies)
                        {
                            if (body.IsTracked)
                            {
                                textBox.Text = "You got: " + HittedBaloonsCounter;
                                Joint jointHandLeft = body.Joints[JointType.HandLeft];

                                textBoxHandPosition.Text = String.Format("{0:N2}", jointHandLeft.Position.X) + " : " + String.Format("{0:N2}", jointHandLeft.Position.Y);
                                
                                foreach (var b in Generator.BaloonsList)
                                {
                                    //textBoxBaloonPosition.Text = Canvas.GetLeft(b) + " : " + Canvas.GetBottom(b);
                                    textBoxBaloonPosition.Text = CoordinatesConverter.convertX(baloonCanvas, Canvas.GetLeft(b)) + " : "
                                        + CoordinatesConverter.convertY(baloonCanvas, Canvas.GetBottom(b));

                                    if (jointHandLeft.Position.X >= CoordinatesConverter.convertX(baloonCanvas, Canvas.GetLeft(b)) - 0.1 && 
                                        jointHandLeft.Position.X <= CoordinatesConverter.convertX(baloonCanvas, Canvas.GetRight(b)) + 0.1 && 
                                        jointHandLeft.Position.Y >= CoordinatesConverter.convertY(baloonCanvas, Canvas.GetBottom(b)) - 0.1 &&
                                        jointHandLeft.Position.Y <= CoordinatesConverter.convertY(baloonCanvas, Canvas.GetTop(b)) + 0.1)
                                    {
                                        HittedBaloonsCounter++;
                                        textBox.Text = "You got: " + HittedBaloonsCounter;
                                    }

                                    var testEllipse = new Ellipse() { Height = 20, Width = 20, Fill = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0)) };
                                    Canvas.SetBottom(testEllipse, 0);
                                    Canvas.SetLeft(testEllipse, 0);

                                }


                                #region SkeletonDrawing
                                //SkeletonDrawing.DrawPoint(JointType.HandLeft, body, _sensor, bodyCanvas);
                                //SkeletonDrawing.DrawPoint(JointType.HandRight, body, _sensor, bodyCanvas);

                                //SkeletonDrawing.DrawLine(JointType.HandLeft, JointType.HandRight, body, bodyCanvas);
                                SkeletonDrawing.DrawSceleton(body, imgCanvas);
                                #endregion
                            }

                        }
                        #endregion


                    }
                }
            }



            #region body v1
            // Body
            //using (var frame = reference.BodyFrameReference.AcquireFrame())
            //{
            //    if (frame != null)
            //    {
            //        canvas.Children.Clear();

            //        _bodies = new Body[frame.BodyFrameSource.BodyCount];

            //        frame.GetAndRefreshBodyData(_bodies);

            //        foreach (var body in _bodies)
            //        {
            //            if (body != null)
            //            {
            //                if (body.IsTracked)
            //                {
            //                    // Draw skeleton.
            //                    if (_displayBody)
            //                    {
            //                        canvas.DrawSkeleton(body);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion
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
