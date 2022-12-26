using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarServices.Model
{
    public partial class Service
    {
        public string DiscountText
        {
            get
            {
                if (Discount == 0 || Discount == null)
                    return "";
                else
                    return $"* скидка {Discount * 100} %";
            }
        }
        public string FullPath
        {
            get
            {
                 return $"/{ServicePhoto.PhotoPath}";
            }
        }
        public double CostWithDiscount
        {
            get
            {
                if (Discount == 0 || Discount == null)
                {
                    return (double)Cost;
                }
                else
                {
                    var costWithDiscount = (double)Cost * (1.00 - Discount);
                    return costWithDiscount.Value;
                }
            }
        }
        public string TotalCost
        {
            get
            {
                if (Discount == 0 || Discount == null)
                {
                    return $"{Cost:N2} рублей за {Convert.ToString(DurationInSeconds / 60)} минут";
                }
                else
                {
                    //Convert.ToInt32(DurationInSeconds)
                    return $"{CostWithDiscount:N2} рублей за {Convert.ToString(DurationInSeconds /60)} минут";
                }
            }
        }
        public Visibility DiscountVisibility
        {
            get
            {
                if (Discount == 0 || Discount == null)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }
        public string BackColor
        {
            get
            {
                if (Discount == 0 || Discount == null)
                    return "#FFFFE1";
                else
                    return "#D1FFD1";
            }
        }

    }
}
