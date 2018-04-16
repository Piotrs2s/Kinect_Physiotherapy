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
  

    static public class SkeletonDrawing 
    {
        static public void DrawPoint(JointType jointType, Body body, KinectSensor _sensor, Canvas bodyCanvas)
        {
            Joint joint = body.Joints[jointType];
            //joint = ScaleTo(joint, bodyCanvas.ActualWidth, bodyCanvas.ActualHeight);
            if (joint.TrackingState == TrackingState.Tracked)
            {
                DepthSpacePoint jointCoordinates = _sensor.CoordinateMapper.MapCameraPointToDepthSpace(joint.Position);


                Ellipse Circle = new Ellipse() { Width = 20, Height = 20, Fill = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0)) };


                bodyCanvas.Children.Add(Circle);
                //Canvas.SetLeft(Circle, joint.Position.X - Circle.Width/2);
                //Canvas.SetTop(Circle, joint.Position.Y - Circle.Height/2);

                Canvas.SetLeft(Circle, jointCoordinates.X - Circle.Width / 2);
                Canvas.SetTop(Circle, jointCoordinates.Y - Circle.Height / 2);


            }

        }

        static public void DrawLine(JointType joint1Type, JointType joint2Type, Body body,  /*KinectSensor _sensor,*/ Canvas bodyCanvas)
        {
            Joint joint1 = body.Joints[joint1Type];
            Joint joint2 = body.Joints[joint2Type];

            Joint joint3 = body.Joints[JointType.HandLeft];


            joint1 = ScaleTo(joint1, bodyCanvas.ActualWidth, bodyCanvas.ActualHeight);
            joint2 = ScaleTo(joint2, bodyCanvas.ActualWidth, bodyCanvas.ActualHeight);
            if (joint1.TrackingState == TrackingState.Tracked && joint2.TrackingState == TrackingState.Tracked)
            {
                //DepthSpacePoint joint1Coordinates = _sensor.CoordinateMapper.MapCameraPointToDepthSpace(joint1.Position);
                //DepthSpacePoint joint2Coordinates = _sensor.CoordinateMapper.MapCameraPointToDepthSpace(joint1.Position);



                Line line = new Line
                {
                    //X1 = joint1Coordinates.X,
                    //Y1 = joint1Coordinates.Y,
                    //X2 = joint2Coordinates.X,
                    //Y2 = joint2Coordinates.Y,
                    X1 = joint1.Position.X+10,
                    Y1 = joint1.Position.Y,
                    X2 = joint2.Position.X+10,
                    Y2 = joint2.Position.Y,
                    StrokeThickness = 8,
                    Stroke = new SolidColorBrush(Colors.Red)
                };

                bodyCanvas.Children.Add(line);

            }
        }

        static public void DrawSceleton(Body body,  Canvas bodyCanvas)
        {
            //Spine
            //DrawLine(JointType.Head, JointType.Neck, body, bodyCanvas);
            //DrawLine(JointType.Neck, JointType.SpineShoulder, body, bodyCanvas);
            //DrawLine(JointType.SpineShoulder, JointType.SpineMid, body, bodyCanvas);
            //DrawLine(JointType.SpineMid, JointType.SpineBase, body, bodyCanvas);
            //Left hand
            //DrawLine(JointType.SpineShoulder, JointType.ShoulderLeft, body, bodyCanvas);
            //DrawLine(JointType.ShoulderLeft, JointType.ElbowLeft, body, bodyCanvas);
            //DrawLine(JointType.ElbowLeft, JointType.WristLeft, body, bodyCanvas);
            DrawLine(JointType.WristLeft, JointType.HandLeft, body, bodyCanvas);
            DrawLine(JointType.HandLeft, JointType.HandTipLeft, body, bodyCanvas);
            DrawLine(JointType.WristLeft, JointType.ThumbLeft, body, bodyCanvas);
            //Right hand
            //DrawLine(JointType.SpineShoulder, JointType.ShoulderRight, body, bodyCanvas);
            //DrawLine(JointType.ShoulderRight, JointType.ElbowRight, body, bodyCanvas);
            //DrawLine(JointType.ElbowRight, JointType.WristRight, body, bodyCanvas);
            DrawLine(JointType.WristRight, JointType.HandRight, body, bodyCanvas);
            DrawLine(JointType.HandRight, JointType.HandTipRight, body, bodyCanvas);
            DrawLine(JointType.WristRight, JointType.ThumbRight, body, bodyCanvas);
            //Left leg
            //DrawLine(JointType.SpineBase, JointType.HipLeft, body, bodyCanvas);
            //DrawLine(JointType.HipLeft, JointType.KneeLeft, body, bodyCanvas);
            //DrawLine(JointType.KneeLeft, JointType.AnkleLeft, body, bodyCanvas);
            //DrawLine(JointType.AnkleLeft, JointType.FootLeft, body, bodyCanvas);
            //Right leg
            //DrawLine(JointType.SpineBase, JointType.HipRight, body, bodyCanvas);
            //DrawLine(JointType.HipRight, JointType.KneeRight, body, bodyCanvas);
            //DrawLine(JointType.KneeRight, JointType.AnkleRight, body, bodyCanvas);
            //DrawLine(JointType.AnkleRight, JointType.FootRight, body, bodyCanvas);

        }

            #region Scailing
            public static Joint ScaleTo(this Joint joint, double width, double height)
        {
            float skeletonMaxX = 1.0f;
            float skeletonMaxY = 1.0f;
            joint.Position = new CameraSpacePoint
            {
                X = Scale(width, skeletonMaxX, joint.Position.X),
                Y = Scale(height, skeletonMaxY, -joint.Position.Y),
                Z = joint.Position.Z
            };

            return joint;
        }

        private static float Scale(double maxPixel, double maxSkeleton, float position)
        {
            float value = (float)((((maxPixel / maxSkeleton) / 2) * position) + (maxPixel / 2));

            if (value > maxPixel)
            {
                return (float)maxPixel;
            }

            if (value < 0)
            {
                return 0;
            }

            return value;
        }
        #endregion
    }
}
