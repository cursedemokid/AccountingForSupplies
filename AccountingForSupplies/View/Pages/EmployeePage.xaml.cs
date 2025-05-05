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
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        List<Employee> _employees = App.context.Employee.ToList();
        public EmployeePage()
        {
            InitializeComponent();

            EmployeeLV.ItemsSource = _employees;
        }

        private void SearchByInitialsTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchByInitialsTbx.Text))
            {
                EmployeeLV.ItemsSource = _employees;
            }
            else
            {
                EmployeeLV.ItemsSource = _employees.Where(em => em.FirstName == SearchByInitialsTbx.Text || em.Surname == SearchByInitialsTbx.Text || em.MiddleName == SearchByInitialsTbx.Text).ToList();
            }
        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditEmployeeWindow addEditEmployeeWindow = new AddEditEmployeeWindow();
            if (addEditEmployeeWindow.ShowDialog() == true)
            {
                FeedbackService.Information("Работник успешно добавлен!");
                EmployeeLV.ItemsSource = _employees;
            }
            else
            {
                FeedbackService.Error("Работник не был добавлен");
            }

        }

        private void EditEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = EmployeeLV.SelectedItem as Employee;
            AddEditEmployeeWindow addEditEmployeeWindow = new AddEditEmployeeWindow(selectedEmployee.Id);
            if (selectedEmployee != null)
            {
                if (addEditEmployeeWindow.ShowDialog() == true)
                {
                    FeedbackService.Information("Данные работника успешно изменены!");
                    EmployeeLV.ItemsSource = _employees;
                }
                else
                {
                    FeedbackService.Error("Данные работника не изменены");
                }
            }
        }

        private void DeleteEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = EmployeeLV.SelectedItem as Employee;
            AddEditEmployeeWindow addEditEmployeeWindow = new AddEditEmployeeWindow();
            if (selectedEmployee != null)
            {
                if (FeedbackService.Question("Вы уверены что хотите удалить сотрудника?") == MessageBoxResult.Yes)
                {
                    try
                    {
                        App.context.Employee.Remove(selectedEmployee);
                        App.context.SaveChanges();
                        FeedbackService.Information("Сотрудник удален");
                    }
                    catch (Exception ex)
                    {
                        FeedbackService.Error(ex.Message);
                    }
                }
            }
        }
    }
}
