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
        public int baloonsHitted { get; set; }
        public int baloonsMissed { get; set; }


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

            this.baloonsHitted = 0;
            this.baloonsFloated = 0;
            this.baloonsMissed = 0;

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
            for (int i = BaloonsList.Count-1; i >= 0; i--)
            {
                if (Canvas.GetBottom(BaloonsList[i]) <= canvas.Height)
                {
                    Canvas.SetBottom(BaloonsList[i], Canvas.GetBottom(BaloonsList[i]) + 1);
                    canvas.Children.Add(BaloonsList[i]);
                }
                else
                {
                    BaloonsList.Remove(BaloonsList[i]);
                    baloonsMissed++;
                }
            }

            #region foreachVersion
            //foreach (var b in BaloonsList)
            //{
            //    if (Canvas.GetBottom(b) <= canvas.Height)
            //    {
            //        Canvas.SetBottom(b, Canvas.GetBottom(b) + 1);
            //        canvas.Children.Add(b);
            //    }
            //    else
            //    {
            //        BaloonsList.Remove(b);
            //    }


            //}
            #endregion
        }

        public void DestroyBaloon(Ellipse baloon)
        {


            baloon.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));

                this._dispatcherTimer.Tick += delegate (object sender, EventArgs e)
                {
                    BaloonExplosion(baloon);

                };            
        }

        void BaloonExplosion(Ellipse baloon)
        {
            if (baloon.Width < 50)
            {
                baloon.Height = baloon.Height + 0.4;
                baloon.Width = baloon.Height + 0.4;
            }
            else
            {
               
                BaloonsList.Remove(baloon);
                return;
            }
                             
        }


     }
}
