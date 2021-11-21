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
    /// Interaction logic for RosterShiftView.xaml
    /// </summary>
    public partial class RosterShiftView : Page
    {
        public RosterShiftView(Employee e)
        {
            DataContext = e;
            InitializeComponent();

            try
            {
                dgShifts.ItemsSource = PayController.Instance.GetShifts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAddToRoster_Click(object sender, RoutedEventArgs e)
        {
            var sft = (Shift)((Button)e.Source).DataContext;
            var emp = (Employee)DataContext;

            try
            {
                PayController.Instance.InsertRosteredShift(emp, sft);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            NavigationService.Navigate(new RosterView(emp));
        }

        private void btnRosterView_Click(object sender, RoutedEventArgs e)
        {
            var emp = (Employee)DataContext;
            NavigationService.Navigate(new RosterView(emp));
        }
    }
}
