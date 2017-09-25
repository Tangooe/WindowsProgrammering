using System;
using System.Windows;
using System.Windows.Shapes;

namespace Exercice2
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

        private void BtnCalculateArea_OnClick(object sender, RoutedEventArgs e)
        {
            var area = (Ellipse.Height / 2) * (Ellipse.Width / 2) * Math.PI;
            MessageBox.Show($"Area = {area}");
        }
    }
}
