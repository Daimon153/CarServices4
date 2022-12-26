using CarServices.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddEditServicePage.xaml
    /// </summary>
    public partial class AddEditServicePage : Page
    {
        Core db = new Core();
     
       private byte[] _mainImageData;
        Service _currentService = null;
        public AddEditServicePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image| *.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                ImageService.Source = (ImageSource)new ImageSourceConverter() .ConvertFrom(_mainImageData);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(_currentService == null)
            {
                Service service = new Service
                {
                    Title = TBoxTitle.Text,
                    Cost = decimal.Parse(TBoxCost.Text);
                };
            }
        }
    }
}
