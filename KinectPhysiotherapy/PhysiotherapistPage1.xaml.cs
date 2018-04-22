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

        
        KinectSensor _sensor;
        MultiSourceFrameReader _reader;

        /// <summary>
        /// Constant for clamping Z values of camera space points from being negative
        /// </summary>
     //KKK   private const float InferredZPositionClamp = 0.1f;

        /// <summary>
        /// Coordinate mapper to map one type of point to another
        /// </summary>
    //KKK    private CoordinateMapper coordinateMapper = null;

        //IList<Body> _bodies; // body ver 1
        Body[] bodies; //body ver 2
        bool _displayBody = false;

      

        public PhysiotherapistPage1(int frequency, int speed)
        {
            InitializeComponent();
            Generator = new BaloonsGenerator(baloonCanvas,frequency, speed); //frequency and speed of baloons (ticks to next baloon and  length of timer tick) 


        }

        //Start recording button
        private void StartRecording(object sender, RoutedEventArgs e)
        {
            _sensor = KinectSensor.GetDefault();
     //KKK       this.coordinateMapper = this._sensor.CoordinateMapper;
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

                        foreach (var body in bodies)
                        {
                            if (body.IsTracked)
                            {
                                #region Depth Tries
                               // IReadOnlyDictionary<JointType, Joint> joints = body.Joints;

                                // convert the joint points to depth (display) space
                                //Dictionary<JointType, Point> jointPoints = new Dictionary<JointType, Point>();

                                //foreach (JointType jointType in joints.Keys)
                                //{
                                //    // sometimes the depth(Z) of an inferred joint may show as negative
                                //    // clamp down to 0.1f to prevent coordinatemapper from returning (-Infinity, -Infinity)
                                //    CameraSpacePoint position = joints[jointType].Position;
                                //    if (position.Z < 0)
                                //    {
                                //        position.Z = InferredZPositionClamp;
                                //    }

                                //    DepthSpacePoint depthSpacePoint = this.coordinateMapper.MapCameraPointToDepthSpace(position);
                                //    jointPoints[jointType] = new Point(depthSpacePoint.X, depthSpacePoint.Y);
                                //}
                                #endregion

                                textBox_baloonsHitted.Text = "Hitted: " + Generator.baloonsHitted;
                                textBox_baloonsFloated.Text = "Floated: " + Generator.baloonsFloated;

                                if (Generator.baloonsFloated > 0)
                                {
                                    double percent = Generator.baloonsHitted * 100 / Generator.baloonsFloated;
                                    textBox_percent.Text = percent + "%";
                                }
                        
                                //CameraSpacePoint position = joints[JointType.HandLeft].Position;
                                //DepthSpacePoint depthSpacePoint = this.coordinateMapper.MapCameraPointToDepthSpace(position);
                                //var leftHandPosition = new Point(depthSpacePoint.X, depthSpacePoint.Y);

                                //var testJointEllipse = new Ellipse() { Height = 5, Width = 5, Fill = new SolidColorBrush(Color.FromArgb(255,0,255,0)) };

                                //Canvas.SetTop(testJointEllipse, leftHandPosition.Y);
                                //Canvas.SetLeft(testJointEllipse, leftHandPosition.X);


                                //bodyCanvas.Children.Add(testJointEllipse);

                                //Joint jointHandLeft = jointPoints[JointType.HandLeft];
                                //Joint jointHandRight = jointPoints[JointType.HandRight];


                                Joint jointHandLeft = body.Joints[JointType.HandLeft];
                                Joint jointHandRight = body.Joints[JointType.HandRight];

                                textBoxHandPosition.Text = String.Format("{0:N2}", jointHandLeft.Position.X) + " : " + String.Format("{0:N2}", jointHandLeft.Position.Y);
                                #region foreachVersion
                                //foreach (var b in Generator.BaloonsList)
                                //{
                                //    //textBoxBaloonPosition.Text = Canvas.GetLeft(b) + " : " + Canvas.GetBottom(b);
                                //    textBoxBaloonPosition.Text = CoordinatesConverter.convertX(baloonCanvas, Canvas.GetLeft(b)) + " : "
                                //        + CoordinatesConverter.convertY(baloonCanvas, Canvas.GetBottom(b));

                                //    if (jointHandLeft.Position.X >= CoordinatesConverter.convertX(baloonCanvas, Canvas.GetLeft(b)) - 0.1 && 
                                //        jointHandLeft.Position.X <= CoordinatesConverter.convertX(baloonCanvas, Canvas.GetLeft(b)) + 0.1 && 
                                //        jointHandLeft.Position.Y >= CoordinatesConverter.convertY(baloonCanvas, Canvas.GetBottom(b)) - 0.1 &&
                                //        jointHandLeft.Position.Y <= CoordinatesConverter.convertY(baloonCanvas, Canvas.GetBottom(b)) + 0.1 ||

                                //        jointHandRight.Position.X >= CoordinatesConverter.convertX(baloonCanvas, Canvas.GetLeft(b)) - 0.1 &&
                                //        jointHandRight.Position.X <= CoordinatesConverter.convertX(baloonCanvas, Canvas.GetLeft(b)) + 0.1 &&
                                //        jointHandRight.Position.Y >= CoordinatesConverter.convertY(baloonCanvas, Canvas.GetBottom(b)) - 0.1 &&
                                //        jointHandRight.Position.Y <= CoordinatesConverter.convertY(baloonCanvas, Canvas.GetBottom(b)) + 0.1)
                                //    {
                                //        b.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                                //        HittedBaloonsCounter++;
                                //        textBox.Text = "Counter: " + HittedBaloonsCounter;

                                //    }
                                //}
                                #endregion
                                for (int i = Generator.BaloonsList.Count - 1; i >= 0; i--)
                                {
                                    textBoxBaloonPosition.Text = CoordinatesConverter.convertX(baloonCanvas, Canvas.GetLeft(Generator.BaloonsList[i])) + " : "
                                        + CoordinatesConverter.convertY(baloonCanvas, Canvas.GetBottom(Generator.BaloonsList[i]));

                                    #region gootjoints
                                    //(jointHandLeft.Position.X >= CoordinatesConverter.convertX(baloonCanvas, Canvas.GetLeft(Generator.BaloonsList[i])) - 0.1 &&
                                    //    jointHandLeft.Position.X <= CoordinatesConverter.convertX(baloonCanvas, Canvas.GetLeft(Generator.BaloonsList[i])) + 0.1 &&
                                    //    jointHandLeft.Position.Y >= CoordinatesConverter.convertY(baloonCanvas, Canvas.GetBottom(Generator.BaloonsList[i])) - 0.1 &&
                                    //    jointHandLeft.Position.Y <= CoordinatesConverter.convertY(baloonCanvas, Canvas.GetBottom(Generator.BaloonsList[i])) + 0.1 ||

                                    //    jointHandRight.Position.X >= CoordinatesConverter.convertX(baloonCanvas, Canvas.GetLeft(Generator.BaloonsList[i])) - 0.1 &&
                                    //    jointHandRight.Position.X <= CoordinatesConverter.convertX(baloonCanvas, Canvas.GetLeft(Generator.BaloonsList[i])) + 0.1 &&
                                    //    jointHandRight.Position.Y >= CoordinatesConverter.convertY(baloonCanvas, Canvas.GetBottom(Generator.BaloonsList[i])) - 0.1 &&
                                    //    jointHandRight.Position.Y <= CoordinatesConverter.convertY(baloonCanvas, Canvas.GetBottom(Generator.BaloonsList[i])) + 0.1)
                                    #endregion

                                    if (jointHandLeft.Position.X >= CoordinatesConverter.convertX(baloonCanvas, Canvas.GetLeft(Generator.BaloonsList[i])) - 0.1 &&
                                        jointHandLeft.Position.X <= CoordinatesConverter.convertX(baloonCanvas, Canvas.GetLeft(Generator.BaloonsList[i])) + 0.1 &&
                                        jointHandLeft.Position.Y >= CoordinatesConverter.convertY(baloonCanvas, Canvas.GetBottom(Generator.BaloonsList[i])) - 0.1 &&
                                        jointHandLeft.Position.Y <= CoordinatesConverter.convertY(baloonCanvas, Canvas.GetBottom(Generator.BaloonsList[i])) + 0.1 ||

                                        jointHandRight.Position.X >= CoordinatesConverter.convertX(baloonCanvas, Canvas.GetLeft(Generator.BaloonsList[i])) - 0.1 &&
                                        jointHandRight.Position.X <= CoordinatesConverter.convertX(baloonCanvas, Canvas.GetLeft(Generator.BaloonsList[i])) + 0.1 &&
                                        jointHandRight.Position.Y >= CoordinatesConverter.convertY(baloonCanvas, Canvas.GetBottom(Generator.BaloonsList[i])) - 0.1 &&
                                        jointHandRight.Position.Y <= CoordinatesConverter.convertY(baloonCanvas, Canvas.GetBottom(Generator.BaloonsList[i])) + 0.1)
                                    {

                                        if (Generator.BaloonsList[i].AllowDrop == false)
                                        {
                                            Generator.BaloonsList[i].AllowDrop = true;
                                            Generator.DestroyBaloon(Generator.BaloonsList[i]);
                                        }
                                        
                                        

                                        #region withoutExplosion
                                        //Generator.baloonsHitted++;
                                        //Generator.BaloonsList.Remove(Generator.BaloonsList[i]);
                                        #endregion
                                    }


                                }

                                #region SkeletonDrawing
                                //SkeletonDrawing.DrawPoint(JointType.HandLeft, body, _sensor, bodyCanvas);
                                //SkeletonDrawing.DrawPoint(JointType.HandRight, body, _sensor, bodyCanvas);

                                //SkeletonDrawing.DrawLine(JointType.HandLeft, JointType.HandRight, body, bodyCanvas);
                                // SkeletonDrawing.DrawSceleton(body, imgCanvas);

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
