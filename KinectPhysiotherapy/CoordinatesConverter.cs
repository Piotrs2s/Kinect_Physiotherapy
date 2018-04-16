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
    public class CoordinatesConverter
    {
        public static double convertX(Canvas baloonCanvas, double xCoordinate )
        {
            double halfOfCanvas = baloonCanvas.Width / 2;

            if (xCoordinate > halfOfCanvas)
            {
                
                double coordinate = xCoordinate - halfOfCanvas;
                double valueProcentage = coordinate/halfOfCanvas ;

                return valueProcentage;
            }

            if (xCoordinate <= halfOfCanvas)
            {
                double coordinate = halfOfCanvas - xCoordinate;
                double valueProcentage = coordinate / halfOfCanvas;

                return -valueProcentage;
            }
            return 0;
        }

        public static double convertY(Canvas baloonCanvas, double yCoordinate)
        {
            double halfOfCanvas = baloonCanvas.Height / 2;

            if (yCoordinate > halfOfCanvas)
            {

                double coordinate = yCoordinate - halfOfCanvas;
                double valueProcentage = coordinate / halfOfCanvas;

                return valueProcentage;
            }

            if (yCoordinate <= halfOfCanvas)
            {
                double coordinate = halfOfCanvas - yCoordinate;
                double valueProcentage = coordinate / halfOfCanvas;

                return -valueProcentage;
            }
            return 0;
        }

    }
}
