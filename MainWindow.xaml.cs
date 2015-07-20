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

namespace AzimuthCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        double _CaclulateBearing(Point point_1, Point point_2)
        {
            double dx = point_2.X - point_1.X;
            double dy = point_2.Y - point_1.Y;

            double angle = 0.0;
            if (dx > 0.0)
            {
                angle = (Math.PI * 0.5) + Math.Atan(dy / dx);
            }
            else if (dx < 0.0)
            {
                angle = (Math.PI * 1.5) + Math.Atan(dy / dx);
            }
            else if (dy > 0.0)
            {
                angle = 0.0;
            }
            else if (dy < 0.0)
            {
                angle = Math.PI;
            }

            return _RadianToDegree(angle);
        }

        private double _RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        private void _Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void _Ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (_moveLine)
            {
                var pos = e.GetPosition(mainEllipse);

                line.X2 = pos.X;
                line.Y2 = pos.Y;

                double bearing = _CaclulateBearing(new Point(300, 300), pos);
                azimuth.Content = Math.Round(bearing);
            }
        }

        private void _MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                _moveLine = _moveLine ? false : true;
            }
        }

        private bool _moveLine = true;
    }
}
