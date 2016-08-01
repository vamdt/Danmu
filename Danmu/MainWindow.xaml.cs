using System;
using System.Collections.Generic;
using System.Globalization;
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
            linesCount = ((int)(Playground.ActualHeight - paddingTop)) % lineHeight;
        }

        private double paddingTop = 5;
        private int lineHeight = 16;
        private int linesCount;

        private Random rand = new Random();

        private double DanmuYPosition(int lineNumber)
        {
            return paddingTop + lineHeight * (lineNumber - 1);
        }

        private int RandomLineNumber()
        {
            return rand.Next(linesCount);
        }


        private void Shoot()
        {
            TextBlock danmu = new TextBlock();
            danmu.Text = "23333333333333333333333333333333333333";
            danmu.TextWrapping = TextWrapping.Wrap;
            double y = DanmuYPosition(RandomLineNumber());
            danmu.Text += " linesCount:" +  linesCount;
            danmu.Text += " position:" + y.ToString();
            danmu.Text += " height:" + danmu.RenderSize.Height;
            danmu.Text += " width:" + danmu.RenderSize.Width;
            danmu.Margin = new Thickness(0, y, 0, 0);
            danmu.LineHeight = lineHeight;
            danmu.Background = Brushes.Red;
            Size danmuSize = MeasureText(danmu);
            danmu.Height = danmuSize.Height;
            danmu.Width = danmuSize.Width;
            danmu.LineStackingStrategy = LineStackingStrategy.BlockLineHeight;
            Playground.Children.Add(danmu);
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = Playground.RenderSize.Width;
            animation.To = -danmu.DesiredSize.Width - 1000;
            animation.SpeedRatio = 0.1;
            TranslateTransform transform = new TranslateTransform();
            danmu.RenderTransform = transform;
            transform.BeginAnimation(TranslateTransform.XProperty, animation);
        }

        private Size MeasureText(TextBlock textBlock)
        {
            FormattedText formattedText = new FormattedText(
                textBlock.Text,
                CultureInfo.CurrentUICulture,
                FlowDirection.LeftToRight,
                new Typeface(textBlock.FontFamily, textBlock.FontStyle, textBlock.FontWeight, textBlock.FontStretch),
                textBlock.FontSize,
                Brushes.Black);
            return new Size(formattedText.Width, formattedText.Height);
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                Shoot();
            }
        }
    }
}
