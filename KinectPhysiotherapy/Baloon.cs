using Microsoft.Kinect;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Threading;

namespace KinectPhysiotherapy
{
    /// <summary>
    /// Interaction logic for PhysiotherapistPage1.xaml
    /// </summary>
    /// 

    public class Baloon
    {
        public Point coordinates;
        public Canvas canvas;
        public Random random;
        public Ellipse baloon;


        public Baloon(Canvas canvas)
        {
            this.canvas = canvas;
            this.baloon = new Ellipse() { Width = 20, Height = 20, Fill = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0)) };

            this.random = new Random();
            this.coordinates = new Point(random.Next(Convert.ToInt32(canvas.Width)), 0.5);
            canvas.Children.Add(baloon);
        }

        

        public void MoveBaloon()
        {


            while (coordinates.Y < canvas.Height)
            {
                canvas.Children.Clear();
                Canvas.SetTop(baloon, coordinates.Y);
                Canvas.SetLeft(baloon, coordinates.X);

                canvas.Children.Add(baloon);
                coordinates.Y = coordinates.Y + 50;
                //Thread.Sleep(1000);
            }
                       
        }
    }
}
