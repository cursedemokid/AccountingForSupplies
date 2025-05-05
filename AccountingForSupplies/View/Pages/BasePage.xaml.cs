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

namespace AccountingForSupplies.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BasePage.xaml
    /// </summary>
    public partial class BasePage : Page
    {
        public BasePage()
        {
            InitializeComponent();

            AdministratorFrame.Navigate(new EmployeePage());
        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {
            AdministratorFrame.Navigate(new ClientPage());
        }

        private void EmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            AdministratorFrame.Navigate(new EmployeePage());
        }

        private void CityBtn_Click(object sender, RoutedEventArgs e)
        {
            AdministratorFrame.Navigate(new EmployeePage());
        }

        private void CompanyBtn_Click(object sender, RoutedEventArgs e)
        {
            AdministratorFrame.Navigate(new EmployeePage());
        }
    }
}
