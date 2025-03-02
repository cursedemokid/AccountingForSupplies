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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        List<Employee> _employees = App.context.Employee.ToList();
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_employees.FirstOrDefault(em => em.Password == PasswordPb.Password && em.Login == LoginTbx.Text) != null)
            {
                App.CurrentEmployee = _employees.FirstOrDefault(em => em.Password == PasswordPb.Password && em.Login == LoginTbx.Text);
                FeedbackService.Information($"Добро пожаловать {App.CurrentEmployee.FullName}");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
        }
    }
}
