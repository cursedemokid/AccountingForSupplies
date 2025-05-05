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
    /// Логика взаимодействия для AddEditEmployeeWindow.xaml
    /// </summary>
    public partial class AddEditEmployeeWindow : Window
    {
        Employee selectedEmployee { get; set; }
        List<Employee> _employees = App.context.Employee.ToList();
        public AddEditEmployeeWindow()
        {
            InitializeComponent();
            AcceptBtn.Visibility = Visibility.Collapsed;
            PositionCmb.ItemsSource = App.context.Position.ToList();
        }

        public AddEditEmployeeWindow(int id)
        {
            InitializeComponent();

            selectedEmployee = _employees.FirstOrDefault(em => em.Id == id);

            MainGrid.DataContext = selectedEmployee;
            PositionCmb.ItemsSource = App.context.Position.ToList();
            PositionCmb.SelectedValue = selectedEmployee.PositionId;
            AddBtn.Visibility = Visibility.Collapsed;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                selectedEmployee.Surname = SurnameTbx.Text;
                selectedEmployee.FirstName = FirstNameTbx.Text;
                selectedEmployee.MiddleName = MiddleNameTbx.Text;
                selectedEmployee.Login = LoginTbx.Text;
                selectedEmployee.Password = PasswordTbx.Text;
                selectedEmployee.PositionId = Convert.ToInt32(PositionCmb.SelectedValue);

                App.context.SaveChanges();
                DialogResult = true;
                Close();
            }
            catch(Exception ex)
            {
                FeedbackService.Error(ex.Message);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee employee = new Employee
                {
                    Surname = SurnameTbx.Text,
                    FirstName = FirstNameTbx.Text,
                    MiddleName = MiddleNameTbx.Text,
                    Login = LoginTbx.Text,
                    Password = PasswordTbx.Text,
                    PositionId = Convert.ToInt32(PositionCmb.SelectedValue),
                };

                if(App.context.Employee.FirstOrDefault(em => em.Login == employee.Login) == null)
                {
                    App.context.Employee.Add(employee);
                    App.context.SaveChanges();
                    DialogResult = true;
                    Close();
                }
                else
                {
                    FeedbackService.Error("Сотрудник с таким логином уже существует! Поменяйте логин и попробуйте заново");
                }
            }
            catch(Exception ex)
            {
                FeedbackService.Error(ex.Message);
            }
        }
    }
}
