using Controllers;
using Domain;
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

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for EmployeesView.xaml
    /// </summary>
    public partial class EmployeesView : Page
    {
        public EmployeesView()
        {
            InitializeComponent();

            try
            {
                dgEmployees.ItemsSource = PayController.Instance.GetEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnShiftsView_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShiftsView());
        }

        private void btnRosterView_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = (Employee)((Button)e.Source).DataContext;
            NavigationService.Navigate(new RosterView(selectedEmployee));
        }

        private void btnPayslipsView_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = (Employee)((Button)e.Source).DataContext;
            NavigationService.Navigate(new PayslipsView(selectedEmployee));
        }
    }
}
