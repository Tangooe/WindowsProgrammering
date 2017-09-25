using System;
using Exercise01.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Exercise01.Data;

namespace Exercise01
{
    public partial class MainWindow : Window
    {
        private readonly List<Language> _languages = new List<Language>();
        private string _jobType;
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSend_OnClick(object sender, RoutedEventArgs e)
        {
            var applicant = new Applicant
            {
                Name = TxtName.Text,
                JobType = _jobType,
                Languages = _languages,
                DesiredProfession = CboProfessions.Text,
                EarliestStartDate = CalEarliestStartDate.SelectedDate ?? DateTime.Now,
            };

            try
            {
                _context.Applicants.Add(applicant);
                _context.SaveChanges();
                MessageBox.Show("Din ansökan är sparad!");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show("Det gick inte att spara till databasen");
            }

        }

        private void LanguageCheckbox_OnUnchecked(object sender, RoutedEventArgs e)
            => _languages.RemoveAll(x => x.Name == (string) (sender as CheckBox)?.Content);

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
            => _languages.Add(new Language {Name = (string) (sender as CheckBox)?.Content});

        private void JobType_OnChecked(object sender, RoutedEventArgs e)
            => _jobType = (string) (sender as RadioButton)?.Content;
    }
}
