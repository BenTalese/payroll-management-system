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
    /// Interaction logic for PayslipsView.xaml
    /// </summary>
    public partial class PayslipsView : Page
    {
        public PayslipsView(Employee e)
        {
            DataContext = e;
            InitializeComponent();

            try
            {
                //dgRosteredShifts.ItemsSource = PayController.Instance.GetRosteredShiftsByEmployeeID(e.EmployeeID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnGeneratePayslipView_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEmployeesView_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeesView());
        }

        private void btnDetailsView_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
