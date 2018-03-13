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
        
       public KinectSensor _sensor;
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

                                //SkeletonDrawing.DrawPoint(JointType.HandLeft, body,_sensor, bodyCanvas);
                                //SkeletonDrawing.DrawPoint(JointType.HandRight, body, _sensor, bodyCanvas);

                                //SkeletonDrawing.DrawLine(JointType.HandLeft, JointType.HandRight, body, bodyCanvas);
                                SkeletonDrawing.DrawSceleton(body, bodyCanvas);
                            }
                        }

                        //void DrawPoint(JointType jointType, Body body, int xShift, int yShift)
                        //{
                        //    //Joint leftHandJoint = body.Joints[JointType.HandLeft];
                        //    Joint joint = body.Joints[jointType];
                        //    if (joint.TrackingState == TrackingState.Tracked)
                        //    {
                        //        DepthSpacePoint dsp = _sensor.CoordinateMapper.MapCameraPointToDepthSpace(joint.Position);


                        //        Ellipse Circle = new Ellipse() { Width = 30, Height = 30, Fill = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0)) };


                        //        bodyCanvas.Children.Add(Circle);
                        //        Canvas.SetLeft(Circle, dsp.X + xShift);
                        //        Canvas.SetTop(Circle, dsp.Y + yShift);
                        //    }

                        //}
                        
                        //void DrawLine(JointType joint1Type, JointType joint2Type, Body body)
                        //{
                        //    Joint joint1 = body.Joints[joint1Type];
                        //    Joint joint2 = body.Joints[joint2Type];
                        //    if (joint1.TrackingState == TrackingState.Tracked && joint2.TrackingState == TrackingState.Tracked)
                        //    {
                        //        DepthSpacePoint dsp1 = _sensor.CoordinateMapper.MapCameraPointToDepthSpace(joint1.Position);
                        //        DepthSpacePoint dsp2 = _sensor.CoordinateMapper.MapCameraPointToDepthSpace(joint1.Position);



                        //        Line line = new Line
                        //        {
                        //            X1 = dsp1.X,
                        //            Y1 = dsp1.Y,
                        //            X2 = dsp2.X,
                        //            Y2 = dsp2.Y,
                        //            StrokeThickness = 8,
                        //            Stroke = new SolidColorBrush(Colors.Red)
                        //        };

                        //        bodyCanvas.Children.Add(line);

                        //    }
                        //}

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
