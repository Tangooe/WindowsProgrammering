using System.Collections.ObjectModel;
using System.Windows;

namespace Exercice01
{
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Person> _personer;
        public MainWindow()
        {
            InitializeComponent();
            _personer = new ObservableCollection<Person>
                { new Person { Name="Mahmud Al Hakim", Email = "abc@mail.com"} };
            DataContext = _personer;
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtName.Text))
                return;

            _personer.Add(new Person { Name = txtName.Text, Email = txtEmail.Text });
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void BtnRemoveSelected_OnClick(object sender, RoutedEventArgs e)
        {
            _personer.Remove((Person) lstPeople.SelectedItem);
        }
    }
}
