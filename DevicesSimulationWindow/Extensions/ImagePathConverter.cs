using System.Windows.Data;
using System.IO;
using System;
using System.Windows.Media.Imaging;

namespace DevicesSimulationWindow.Extensions
{
    public class ImagePathConverter : IValueConverter
    {
        private string imageDirectory = Directory.GetCurrentDirectory();
        public string ImageDirectory
        {
            get { return imageDirectory; }
            set { imageDirectory = value; }
        }
        public object Convert(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
        {
            string imagePath = Path.Combine(ImageDirectory,
            (string)value);
            return new BitmapImage(new Uri(imagePath));
        }
        public object ConvertBack(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
