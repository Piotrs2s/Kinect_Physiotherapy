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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Timers;

namespace KinectPhysiotherapy
{
    public class BaloonsGenerator
    {
        public List<Ellipse> BaloonsList { get; set; }
        public Canvas canvas { get; set; }
        public int baloonsFloated { get; set; }


        private int _frequencyCounter;
        private int _frequency;
        private int _speed;
        private DispatcherTimer _dispatcherTimer;
        private Random _rand;


        public BaloonsGenerator(Canvas canv, int frequency, int speed)
        {
 
            this._frequency = frequency;
            this._speed = speed;
            this._frequencyCounter = 0;
            this.baloonsFloated = 1;

            this._rand = new Random();
            this.canvas = canv;

            this.BaloonsList = new List<Ellipse>();

            this._dispatcherTimer = new DispatcherTimer();
        }

        public void Start()
        {


            this._dispatcherTimer.Tick += new EventHandler(NewBaloon);
            this._dispatcherTimer.Tick += new EventHandler(MoveBaloon);
            
            this._dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, _speed);
            this._dispatcherTimer.Start();
        }

        void NewBaloon(object sender, EventArgs e)
        {
            _frequencyCounter++;
            if (_frequencyCounter == _frequency)
            {
                var baloon = new Ellipse() { Height = 20, Width = 20, Fill = new SolidColorBrush(Color.FromArgb(255, Convert.ToByte(_rand.Next(0, 255)), Convert.ToByte(_rand.Next(0, 255)), Convert.ToByte(_rand.Next(0, 255)))) };
                Canvas.SetBottom(baloon, 0);                
                Canvas.SetLeft(baloon, _rand.Next(0, Convert.ToInt32(canvas.Width)));
                canvas.Children.Add(baloon);
                BaloonsList.Add(baloon);
                baloonsFloated++;

                _frequencyCounter = 0;
            }

        }

        void MoveBaloon(object sender, EventArgs e)
        {

            canvas.Children.Clear();
            foreach (var b in BaloonsList)
            {
               
                    Canvas.SetBottom(b, Canvas.GetBottom(b) + 1);
                    canvas.Children.Add(b);
                
            }

        }
    }
}
