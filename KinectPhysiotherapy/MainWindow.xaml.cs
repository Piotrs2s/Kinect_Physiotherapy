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

namespace KinectPhysiotherapy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private KinectSensor kinect = null;
        private string statusText = null;

        public MainWindow()
        {
            this.kinect = KinectSensor.GetDefault();
            this.kinect.IsAvailableChanged += this.Sensor_IsAvailableChanged;
            this.StatusText = this.kinect.IsAvailable ? "Kinect available." : " Kinect is Unavailable"; 
            this.DataContext = this;

            InitializeComponent();

            this.kinect.Open();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Sensor_IsAvailableChanged(object sender, IsAvailableChangedEventArgs e)
        {
            this.StatusText = this.kinect.IsAvailable ? "Kinect available." : "Goodbie World! Kinect is Unavailable!";
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
            if (this.kinect != null) 
            {
                this.kinect.Close();
                this.kinect = null;
            }
        }


    }
}
