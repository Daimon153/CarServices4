using CarServices.Model;
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

namespace CarServices.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        Core db = new Core();
        List<Service> arrayService;
        public ServicePage()
        {
            InitializeComponent();
            arrayService = db.context.Services.ToList();
            LViewServices.ItemsSource = arrayService;
            ComboDiscount.SelectedIndex = 0;
            ComboSortBy.SelectedIndex = 0;
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateServices();
        }
        private void UpdateServices()
        {
            var services = db.context.Services.ToList();

            if (ComboSortBy.SelectedIndex == 0)
                services = services.OrderBy(p => p.CostWithDiscount).ToList();
            else
                services = services.OrderByDescending(P => P.CostWithDiscount).ToList();
            if (ComboSortBy.SelectedIndex == 1)
                services = services.OrderBy(p => p.Discount >= 0 && p.Discount < 0.05 ).ToList();
            if (ComboSortBy.SelectedIndex == 2)
                services = services.OrderBy(p => p.Discount >= 0.05 && p.Discount < 0.15).ToList();
            if (ComboSortBy.SelectedIndex == 3)
                services = services.OrderBy(p => p.Discount >= 0.15 && p.Discount < 0.30).ToList();
            if (ComboSortBy.SelectedIndex == 4)
                services = services.OrderBy(p => p.Discount >= 0.30 && p.Discount < 0.70).ToList();
            if (ComboSortBy.SelectedIndex == 5)
                services = services.OrderBy(p => p.Discount >= 0.70 && p.Discount < 1).ToList();

            services = services.Where(p => p.Title.ToLower().Contains(TBoxsearch.Text.ToLower())).ToList();

            LViewServices.ItemsSource = services;
        }

        private void ComboDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateServices();
        }

        private void TBoxsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateServices();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LViewServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
