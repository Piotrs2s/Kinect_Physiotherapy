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

namespace KinectPhysiotherapy
{
    /// <summary>
    /// Interaction logic for BaloonsDifficultyLevelPage.xaml
    /// </summary>
    public partial class BaloonsDifficultyLevelPage : Page
    {

        public int frequency;
        public int speed;

        public BaloonsDifficultyLevelPage()
        {
            InitializeComponent();
        }


        private void baloons_veryEasyButton_Click(object sender, RoutedEventArgs e)
        {
            frequency = 60;
            speed = 45;
            Main.Content = new BaloonsMainPage(frequency, speed);
        }
        private void baloons_easyButton_Click(object sender, RoutedEventArgs e)
        {
            frequency = 45;
            speed = 30;
            Main.Content = new BaloonsMainPage(frequency, speed);
        }

        private void baloons_mediumButton_Click(object sender, RoutedEventArgs e)
        {
            frequency = 30;
            speed = 20;
            Main.Content = new BaloonsMainPage(frequency, speed);
        }

        private void baloons_hardButton_Click(object sender, RoutedEventArgs e)
        {
            frequency = 20;
            speed = 15;
            Main.Content = new BaloonsMainPage(frequency, speed);
        }


    }
}
