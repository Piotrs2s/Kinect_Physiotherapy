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
using System.ComponentModel;
using System.Windows.Media.Imaging;
using Microsoft.Kinect.Wpf.Controls;





namespace KinectPhysiotherapy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        
        private KinectSensor sensor;
        private string statusText;
        
        public MainWindow()
        {
            InitializeComponent();            
            this.Loaded += MainPage_Loaded;
        }


        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            


            //Check if Kinect is available
            this.sensor = KinectSensor.GetDefault();
            this.sensor.IsAvailableChanged += this.Sensor_IsAvailableChanged;
            this.StatusText = this.sensor.IsAvailable ? "Kinect available." : " Kinect is Unavailable";
            this.DataContext = this;

            this.sensor.Open();
        }
        #region IsAvailableInfo  
        public event PropertyChangedEventHandler PropertyChanged;

        private void Sensor_IsAvailableChanged(object sender, IsAvailableChangedEventArgs e)
        {
            this.StatusText = this.sensor.IsAvailable ? "Kinect available." : " Kinect is Unavailable";
        }

        public string StatusText
        {
            get
            {
                return this.statusText;
            }

            set
            {
                if (this.statusText != value)
                {
                    this.statusText = value;

                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new PropertyChangedEventArgs("StatusText"));
                    }
                }
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (this.sensor != null) 
            {
                this.sensor.Close();
                this.sensor = null;
            }
        }

        #endregion

        private void PhysiotherapistButton1_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new BaloonsDifficultyLevelPage();
            
        }
    }
}
