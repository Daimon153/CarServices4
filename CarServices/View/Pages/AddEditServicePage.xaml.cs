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
            try

            {
                OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image |*.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                _mainImageData = File.ReadAllBytes(ofd.FileName);
                ImageService.Source = (ImageSource)new ImageSourceConverter()
                    .ConvertFrom(_mainImageData);
            }

            string newfilename = "/Assets/Images/";
            string appFolderPath = Directory.GetCurrentDirectory();
            appFolderPath = appFolderPath.Replace("\\bin\\Debug", "");
            string imageName = System.IO.Path.GetFileName(ofd.FileName);
            newfilename = appFolderPath + newfilename + imageName;
            if (!File.Exists(ofd.FileName))
            {
                File.Copy(ofd.FileName, newfilename);
            }
            

          
                ServicePhoto obj = new ServicePhoto
                {
                    PhotoPath = $"Images/{System.IO.Path.GetFileName(ofd.FileName)}",
                    
                };

                db.context.ServicePhotoes.Add(obj);
                db.context.SaveChanges();

                _currentService.MainImagePath = obj.ID;




            }
            catch
            {
                MessageBox.Show("Критический сбор в работе приложения:", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(_currentService == null)
            {
                Service service = new Service
                {
                    Title = TBoxTitle.Text,
                    Cost = decimal.Parse(TBoxCost.Text),
                    DurationInSeconds = int.Parse(TBoxDuration.Text)*60,
                    Description= TBoxDescription.Text,
                    Discount = string.IsNullOrWhiteSpace(TBoxDiscount.Text)? 0: int.Parse(TBoxDiscount.Text)/100,
                   
                };
            }
        }
    }
}
