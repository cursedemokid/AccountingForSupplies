using AccountingForSupplies.AppData;
using AccountingForSupplies.View.Windows;

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
    /// Логика взаимодействия для CompanyPage.xaml
    /// </summary>
    public partial class CompanyPage : Page
    {
        List<Company> _company = App.context.Company.ToList();
        public CompanyPage()
        {
            InitializeComponent();

            CompanyLV.ItemsSource = _company;
        }

        private void SearchByNameTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(SearchByNameTbx.Text))
            {
                CompanyLV.ItemsSource = _company;
            }
            else
            {

                CompanyLV.ItemsSource = _company.Where(c => c.Name == SearchByNameTbx.Text).ToList();
            }
        }

        private void DeleteCompanyBtn_Click(object sender, RoutedEventArgs e)
        {
            Company selectedCompany = CompanyLV.SelectedItem as Company;
            if(selectedCompany != null)
            {
                if (FeedbackService.Question("Вы уверены что хотите удалить запись?") == MessageBoxResult.Yes)
                {
                    App.context.Company.Remove(selectedCompany);
                    App.context.SaveChanges();
                    FeedbackService.Information("Запись успешно удалена!");
                }
            }
        }

        private void EditCompanyBtn_Click(object sender, RoutedEventArgs e)
        {
            Company selectedCompany = CompanyLV.SelectedItem as Company;
            if (selectedCompany != null)
            {
                AddEditCompanyWindow addEditCompanyWindow = new AddEditCompanyWindow(selectedCompany.Id);
                addEditCompanyWindow.ShowDialog();

            }
        }

        private void AddCompanyBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditCompanyWindow addEditCompanyWindow = new AddEditCompanyWindow();
            addEditCompanyWindow.ShowDialog();
        }
    }
}
