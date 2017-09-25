using System;
using System.Windows;
using Microsoft.Win32;

namespace WindowsProgrammering_Assignment01
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

        private void BtnOpen_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() != true)
                return;

            MediaElement.Source = new Uri(fileDialog.FileName);
            MediaElement.Play();
        }

        private void BtnPlay_OnClick(object sender, RoutedEventArgs e)
        {
            if(MediaElement.Source != null)
                MediaElement.Play();
        }

        private void BtnPause_OnClick(object sender, RoutedEventArgs e)
        {
            if (MediaElement.Source != null)
                MediaElement.Pause();
        }

        private void BtnStop_OnClick(object sender, RoutedEventArgs e)
        {
            if (MediaElement.Source != null)
                MediaElement.Stop();
        }
    }
}
