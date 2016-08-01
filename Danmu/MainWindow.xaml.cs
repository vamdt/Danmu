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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Danmu
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            TextBlock danmu = new TextBlock();
            danmu.Text = "23333333333333333333333333333333333333";
            playground.Children.Add(danmu);
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = playground.RenderSize.Width;
            animation.To = -danmu.DesiredSize.Width - 1000;
            animation.SpeedRatio = 0.1;
            TranslateTransform transform = new TranslateTransform();
            danmu.RenderTransform = transform;
            transform.BeginAnimation(TranslateTransform.XProperty, animation);
        }
    }
}
