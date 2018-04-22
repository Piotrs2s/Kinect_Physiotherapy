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
using Microsoft.Kinect;

namespace KinectPhysiotherapy
{


    public class BaloonsGenerator
    {
        //List of actually existing baloons
        public List<Ellipse> BaloonsList { get; set; }
        //Canvas of baloons
        public Canvas canvas { get; set; }
        //Floated baloons couter
        public int baloonsFloated { get; set; }
        //Hitted baloons couter
        public int baloonsHitted { get; set; }
        //Missed baloons couter
        public int baloonsMissed { get; set; }

        //Time span between creating new baloon
        private int _frequency;
        //Actual time span from creating last baloon
        private int _frequencyCounter;
        
        //Speed of baloon (lenght of timer tick that causes baloon moving event)
        private int _speed;
        //Timer
        private DispatcherTimer _dispatcherTimer;
        //Random for baloons color and x coordinate
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


            this._dispatcherTimer.Tick += new EventHandler(NewBaloon); //One tick increases a frequency counter 
            this._dispatcherTimer.Tick += new EventHandler(MoveBaloon);


            this._dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, _speed);
            this._dispatcherTimer.Start();
        }

        //Method that creates new baloon
        void NewBaloon(object sender, EventArgs e)
        {
            _frequencyCounter++;
            if (_frequencyCounter == _frequency) //Create new baloon when frequency counter equals to the seted frequency
            {

                var baloon = new Ellipse() { Height = 20, Width = 20, Fill = new SolidColorBrush(Color.FromArgb(255, Convert.ToByte(_rand.Next(0, 200)), Convert.ToByte(_rand.Next(0, 255)), Convert.ToByte(_rand.Next(0, 255)))) };
                baloon.AllowDrop = false; //Mark baloon as non-caught

                //Set coordinates of baloon
                Canvas.SetBottom(baloon, 0);
                Canvas.SetLeft(baloon, _rand.Next(0, Convert.ToInt32(canvas.Width)));


                canvas.Children.Add(baloon);
                BaloonsList.Add(baloon);
                baloonsFloated++;

                //Reset frequency couter for next baloon
                _frequencyCounter = 0;
            }

        }

        void MoveBaloon(object sender, EventArgs e)
        {
            //Clear old positions of baloons
            canvas.Children.Clear();
            //Change coordinates of all existing baloons
            for (int i = BaloonsList.Count-1; i >= 0; i--)
            {   
                //Check if baloon is not crossing the top
                if (Canvas.GetBottom(BaloonsList[i]) <= canvas.Height)
                {
                    Canvas.SetBottom(BaloonsList[i], Canvas.GetBottom(BaloonsList[i]) + 1);
                    canvas.Children.Add(BaloonsList[i]);
                }
                else
                {
                    //Detete baloon if its crossing the top
                    BaloonsList.Remove(BaloonsList[i]);
                    baloonsMissed++;
                }
            }

           
        }

        public void DestroyBaloon(Ellipse baloon)
        {

         
            baloon.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            baloon.Opacity = .8;

            var doubleAnimationWidth = new DoubleAnimation();
            doubleAnimationWidth.From = baloon.Width;
            doubleAnimationWidth.To = baloon.Width + 20;
            doubleAnimationWidth.Duration = new Duration(TimeSpan.FromMilliseconds(5000));

            var doubleAnimationHeight = new DoubleAnimation();
            doubleAnimationHeight.From = baloon.Height;
            doubleAnimationHeight.To = baloon.Height + 20;
            doubleAnimationHeight.Duration = new Duration(TimeSpan.FromMilliseconds(5000));


            baloon.BeginAnimation(Ellipse.WidthProperty, doubleAnimationWidth);
            baloon.BeginAnimation(Ellipse.HeightProperty, doubleAnimationHeight);
            
            //Count hitted baloon
            baloonsHitted++;
            //Remove baloon from baloons list
            BaloonsList.Remove(baloon);
            

           

            #region storyboard
            //#region storyboard
            //baloon.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            //var storyboard = new Storyboard();

            //var doubleAnimation = new DoubleAnimation();
            //doubleAnimation.From = baloon.Width;
            //doubleAnimation.To = baloon.Width + 10;
            //doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(3000));

            //Storyboard.SetTargetName(doubleAnimation, baloon.Name);
            //Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(baloon.Width));

            //Storyboard WidthStoryboard = new Storyboard();
            //WidthStoryboard.Children.Add(doubleAnimation);

            //WidthStoryboard.Begin(baloon);
            #endregion

            #region storyboard 2
            //DoubleAnimation widthAnimation = new DoubleAnimation
            //{
            //    From = 0,
            //    To = 10,
            //    Duration = TimeSpan.FromSeconds(5)
            //};

            //DoubleAnimation heightAnimation = new DoubleAnimation
            //{
            //    From = 0,
            //    To = 10,
            //    Duration = TimeSpan.FromSeconds(5)
            //};

            //Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(Ellipse.WidthProperty));
            //Storyboard.SetTarget(widthAnimation, baloon);

            //Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(Ellipse.HeightProperty));
            //Storyboard.SetTarget(heightAnimation, baloon);

            //Storyboard s = new Storyboard();
            //s.Children.Add(widthAnimation);
            //s.Children.Add(heightAnimation);
            //s.Begin();
            #endregion

            #region event
            //this._dispatcherTimer.Tick += delegate (object sender, EventArgs e)
            //{
            //    BaloonExplosion(baloon);

            //};
            #endregion
        }

        #region BaloonExplosion
        //void BaloonExplosion(Ellipse baloon)
        //{
        //    if (baloon.Width < 50)
        //    {
        //        baloon.Height = baloon.Height + 0.4;
        //        baloon.Width = baloon.Height + 0.4;
        //    }
        //    else
        //    {

        //        BaloonsList.Remove(baloon);
        //        return;
        //    }

        //}
        #endregion

        //Check if baloon is caught
        public bool BaloonIsCaught(Joint jointHandLeft, Joint jointHandRight, Ellipse ellipse)
        {
            if (jointHandLeft.Position.X >= CoordinatesConverter.convertX(canvas, Canvas.GetLeft(ellipse)) - 0.1 &&
                                        jointHandLeft.Position.X <= CoordinatesConverter.convertX(canvas, Canvas.GetLeft(ellipse)) + 0.1 &&
                                        jointHandLeft.Position.Y >= CoordinatesConverter.convertY(canvas, Canvas.GetBottom(ellipse)) - 0.1 &&
                                        jointHandLeft.Position.Y <= CoordinatesConverter.convertY(canvas, Canvas.GetBottom(ellipse)) + 0.1 ||

                                        jointHandRight.Position.X >= CoordinatesConverter.convertX(canvas, Canvas.GetLeft(ellipse)) - 0.1 &&
                                        jointHandRight.Position.X <= CoordinatesConverter.convertX(canvas, Canvas.GetLeft(ellipse)) + 0.1 &&
                                        jointHandRight.Position.Y >= CoordinatesConverter.convertY(canvas, Canvas.GetBottom(ellipse)) - 0.1 &&
                                        jointHandRight.Position.Y <= CoordinatesConverter.convertY(canvas, Canvas.GetBottom(ellipse)) + 0.1)
            {
                return true;
            }
            else
                return false;
        }
    }
}
