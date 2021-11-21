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
    /// Interaction logic for RosterView.xaml
    /// </summary>
    public partial class RosterView : Page
    {
        public RosterView(Employee e)
        {
            DataContext = e;
            InitializeComponent();

            try
            {
                dgRosteredShifts.ItemsSource = PayController.Instance.GetRosteredShiftsByEmployeeID(e.EmployeeID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRosterShiftView_Click(object sender, RoutedEventArgs e)
        {
            // roster shift for employee, only need ShiftID
            var emp = (Employee)((Button)e.Source).DataContext;
            NavigationService.Navigate(new RosterShiftView(emp));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // should only be able to delete a shift if payslip for employee isn't being processed
        }

        private void btnEmployeesView_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeesView());
        }
    }
}
