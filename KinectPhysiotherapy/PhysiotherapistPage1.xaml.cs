using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for PhysiotherapistPage1.xaml
    /// </summary>
    /// 
   
    public partial class PhysiotherapistPage1 : Page
    {
        
        KinectSensor _sensor;
        MultiSourceFrameReader _reader;
        //IList<Body> _bodies; // body ver 1
        Body[] bodies; //body ver 2
        bool _displayBody = false;

        public PhysiotherapistPage1()
        {
            InitializeComponent();
        }

        //Start recording button
        private void StartRecording(object sender, RoutedEventArgs e)
        {
            _sensor = KinectSensor.GetDefault();

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
                        bodyCanvas.Children.Clear();

                        foreach (var body in bodies)
                        {
                            if (body.IsTracked)
                            {

                                Joint leftHandJoint = body.Joints[JointType.HandLeft];
                                if (leftHandJoint.TrackingState == TrackingState.Tracked)
                                {
                                    DepthSpacePoint dsp = _sensor.CoordinateMapper.MapCameraPointToDepthSpace(leftHandJoint.Position);


                                    Ellipse LeftHandCircle = new Ellipse() { Width = 50, Height = 50, Fill = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0)) };


                                    bodyCanvas.Children.Add(LeftHandCircle);


                                    Canvas.SetLeft(LeftHandCircle, dsp.X);
                                    Canvas.SetTop(LeftHandCircle, dsp.Y - 100);
                                }
                            }
                        }

                    }
                }
            }
           

            

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
