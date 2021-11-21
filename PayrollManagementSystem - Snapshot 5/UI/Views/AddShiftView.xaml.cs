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
    /// Interaction logic for AddShiftView.xaml
    /// </summary>
    public partial class AddShiftView : Page
    {
        public AddShiftView()
        {
            InitializeComponent();
            DataContext = new Shift();
        }

        private void btnAddShift_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PayController.Instance.InsertShift((e.Source as Button).DataContext as Shift);
                NavigationService.Navigate(new ShiftsView());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShiftsView());
        }
    }
}
