using System;
using System.Windows;

namespace Exercice3
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

        private void BtnPlay01_OnClick(object sender, RoutedEventArgs e)
        {
            MusicPlayer.Source = new Uri("c:\\users\\tango\\source\\repos\\WindowsProgrammeringDag1\\Exercice3\\Mp3Files\\kreti_och_pleti-angaende_odmjukhet.mp3");
            MusicPlayer.Play();
        }

        private void BtnPlay02_OnClick(object sender, RoutedEventArgs e)
        {
            MusicPlayer.Source = new Uri("c:\\users\\tango\\source\\repos\\WindowsProgrammeringDag1\\Exercice3\\Mp3Files\\kreti_och_pleti-hymn_till_warezhavet.mp3");
            MusicPlayer.Play();
        }

        private void BtnPlay03_OnClick(object sender, RoutedEventArgs e)
        {
            MusicPlayer.Source = new Uri("c:\\users\\tango\\source\\repos\\WindowsProgrammeringDag1\\Exercice3\\Mp3Files\\kreti_och_pleti-kungens_pung.mp3");
            MusicPlayer.Play();
        }

        private void BtnPlay04_OnClick(object sender, RoutedEventArgs e)
        {
            MusicPlayer.Source = new Uri("c:\\users\\tango\\source\\repos\\WindowsProgrammeringDag1\\Exercice3\\Mp3Files\\kreti_och_pleti-ni_ska_fa_se_att_allt_blir_bra.mp3");
            MusicPlayer.Play();
        }

        private void BtnPlay05_OnClick(object sender, RoutedEventArgs e)
        {
            MusicPlayer.Source = new Uri("c:\\users\\tango\\source\\repos\\WindowsProgrammeringDag1\\Exercice3\\Mp3Files\\kreti_och_pleti-vackrast_av_alla.mp3");
            MusicPlayer.Play();
        }
    }
}
