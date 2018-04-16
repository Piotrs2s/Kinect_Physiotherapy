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

    public class Baloon : Shape
    {
      
        public Random _rand;
        public Ellipse baloon;
        protected override Geometry DefiningGeometry { get; }


        public Baloon()
        {
            //this._rand = new Random();
            //this.baloon = new Ellipse() { Height = 20, Width = 20, Fill = new SolidColorBrush(Color.FromArgb(Convert.ToByte(_rand.Next(0, 255)), Convert.ToByte(_rand.Next(0, 255)), Convert.ToByte(_rand.Next(0, 255)), 0)) };            
        }

        
        
    }
}
