using AccountingForSupplies.AppData;

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
using System.Windows.Shapes;

namespace AccountingForSupplies.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditCompanyWindow.xaml
    /// </summary>
    public partial class AddEditCompanyWindow : Window
    {
        Company currentCompany { get; set; }
        public AddEditCompanyWindow()
        {
            InitializeComponent();

            AcceptBtn.Visibility = Visibility.Collapsed;
            CityCmb.ItemsSource = App.context.City.ToList();
        }
        public AddEditCompanyWindow(int id)
        {
            InitializeComponent();

            currentCompany = App.context.Company.FirstOrDefault(x => x.Id == id);

            LoginTbx.DataContext = currentCompany;
            AddBtn.Visibility = Visibility.Collapsed;

            CityCmb.ItemsSource = App.context.City.ToList();
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            currentCompany.Name = LoginTbx.Text;
            currentCompany.CityId = Convert.ToInt32(CityCmb.SelectedValue);
            App.context.SaveChanges();
            FeedbackService.Information("Запись успешно сохранена");
            Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Company newCompany = new Company
                {
                    Name = LoginTbx.Text,
                    CityId = Convert.ToInt32(CityCmb.SelectedValue),
                };

                App.context.Company.Add(newCompany);
                App.context.SaveChanges();
                FeedbackService.Information("Запись успешно добавлена!");
                Close();
            }
            catch (Exception ex)
            {
                FeedbackService.Error(ex.Message);
            }


        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
