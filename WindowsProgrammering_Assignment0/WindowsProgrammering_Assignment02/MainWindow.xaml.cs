using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WindowsProgrammering_Assignment02.Data;
using WindowsProgrammering_Assignment02.Models;

namespace WindowsProgrammering_Assignment02
{
    public partial class MainWindow : Window
    {
        private readonly ApplicationDbContext _context;
        private readonly ObservableCollection<Customer> _customers;

        public MainWindow()
        {
            InitializeComponent();

            _customers = new ObservableCollection<Customer>();
            _context = new ApplicationDbContext();

            // Om inte databasen är populerad med några kunder så pre-populerar den databasen med en test kund
            if (!_context.Customers.Any())
            {
                _context.Customers.Add(new Customer
                {
                    CustomerType = CustomerType.Private,
                    Company = "TestCompany",
                    ContactPerson = "The Test Guy",
                    BirthDate = DateTime.Now,
                    Address = "TestStreet 1",
                    City = "Test City",
                    PostalCode = "12345",
                    Phone = "070 555 55 55",
                    Email = "test@domain.com",
                    Newsletter = false,
                    Notes = "Testing",
                });
                _context.SaveChanges();
            }

            // Hämtar alla kunder från databasen och lägger in dem i _customer listan
            _context.Customers.ForEachAsync(c => _customers.Add(c)).Wait();

            // Binder _customers till kundlistan
            lstCustomers.ItemsSource = _customers;

            // Filtrerar listan utifrån CustomerFilter metoden
            var view = (CollectionView)CollectionViewSource.GetDefaultView(lstCustomers.ItemsSource);
            view.Filter = CustomerFilter;
        }

        /// <summary>
        /// Filtrerar på Email och Telefonnummer utifrån vad som står i sökfältet
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Sant om det finns något som matchar</returns>
        private bool CustomerFilter(object item)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                return true;

            //Om sökfältet inte är tomt så kollas kunden om värderna matchar
            var customer = item as Customer;
            return customer.Email.ToLower().Contains(txtSearch.Text.ToLower()) ||
                   customer.Phone.ToLower().Contains(txtSearch.Text.ToLower());
        }

        /// <summary>
        /// Lägger till en kund i databasen utifrån datan i formuläret
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            // Kollar om formuläret int är korrekt ifyllt
            if (!IsFormValid())
            {
                // Visar en messagebox om formet inte är korrekt ifyllt
                MessageBox.Show("Formuläret är inte korrekt ifyllt");
                // Ser till så att resten utav koden i metoden inte körs
                return;
            }

            // Skapar en ny kund utifrån datan i formuläret
            var customer = new Customer
            {
                CustomerType = radPrivate.IsChecked == true ? CustomerType.Private : CustomerType.Company,
                Company = radPrivate.IsChecked == true ? txtCompany.Text : string.Empty,
                ContactPerson = txtContactPersonName.Text,
                BirthDate = (DateTime) dtptxtContactBirthdate.SelectedDate,
                Address = txtAddress.Text,
                City = txtCity.Text,
                PostalCode = txtPostalCode.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                Newsletter = cboNewsletter.IsChecked == true,
                Notes = txtNotes.Text
            };

            try
            {
                // Sparar kunden i databasen
                _context.Customers.Add(customer);
                _context.SaveChanges();

                // Lägger till kunden i kundlistan
                _customers.Add(customer);


                // Tömmer formuläret
                EmptyForm();
            }
            catch (Exception exception)
            {
                // Om kunden misslyckas att sparas till databasen så meddelas användaren om det
                Console.WriteLine(exception);
                MessageBox.Show("Misslyckades att spara till databasen");
            }
        }

        /// <summary>
        /// Kontrollerar så att formet inte har tomma fält
        /// </summary>
        /// <returns>Sant om formet är godkänt</returns>
        private bool IsFormValid()
        {
            return !(dtptxtContactBirthdate.SelectedDate == null ||
                   string.IsNullOrWhiteSpace(txtContactPersonName.Text) ||
                   string.IsNullOrWhiteSpace(txtAddress.Text) ||
                   string.IsNullOrWhiteSpace(txtCity.Text) ||
                   string.IsNullOrWhiteSpace(txtPostalCode.Text) ||
                   string.IsNullOrWhiteSpace(txtPhone.Text) ||
                   string.IsNullOrWhiteSpace(txtEmail.Text));
        }

        /// <summary>
        /// När en kund väljs ifrån kundlistan så fyller den formuläret med dess data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LstCustomers_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateForm(lstCustomers.SelectedItem as Customer);
        }

        /// <summary>
        /// När texten ändras i sökfältet så updateras kundlistan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSearch_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lstCustomers.ItemsSource).Refresh();
        }

        /// <summary>
        /// Populerar formet med data utifrån den valda kunden i kundlistan
        /// </summary>
        /// <param name="customer"></param>
        private void PopulateForm(Customer customer)
        {
            radPrivate.IsChecked = customer.CustomerType == CustomerType.Private;
            radCompany.IsChecked = customer.CustomerType == CustomerType.Company;
            txtCompany.Text = customer.Company;
            txtContactPersonName.Text = customer.ContactPerson;
            dtptxtContactBirthdate.SelectedDate = customer.BirthDate;
            txtAddress.Text = customer.Address;
            txtCity.Text = customer.City;
            txtPostalCode.Text = customer.PostalCode;
            txtPhone.Text = customer.Phone;
            txtEmail.Text = customer.Email;
            cboNewsletter.IsChecked = customer.Newsletter;
            txtNotes.Text = customer.Notes;
        }

        /// <summary>
        /// Tömmer formet på data
        /// </summary>
        private void EmptyForm()
        {
            // Hämtar alla textboxar som ligger direkt under Form Stackpanelen och tömmer dem
            foreach (var txtToEmpty in stpForm.Children.OfType<TextBox>().Where(tb => tb.Text != string.Empty))
            {
                txtToEmpty.Text = string.Empty;
            }

            // Tömmer de två fälten som inte ligger direkt under Form Stackpanelen
            txtContactPersonName.Text = string.Empty;
            dtptxtContactBirthdate.SelectedDate = null;
        }
    }
}
