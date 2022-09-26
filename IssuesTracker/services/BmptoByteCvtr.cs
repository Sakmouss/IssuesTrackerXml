using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace IssuesTracker.services
{
    [ValueConversion(typeof(BitmapImage), typeof(Byte[]))]
    class BmptoByteCvtr : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Byte[] array = (Byte[])value;
            var image = new BitmapImage();
            if (array != null)
            {

                using (var ms = new System.IO.MemoryStream(array))
                {
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad; 
                    image.StreamSource = ms;
                    image.EndInit();
                    return image;
                }
            }
            else { return null; }
        }

       

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            Byte[] buffer = null;
            if (value != null)
            {
                BitmapImage bmp = (BitmapImage)value;


                using (FileStream stream = new FileStream(bmp.UriSource.OriginalString, FileMode.OpenOrCreate, FileAccess.Read))
                {


                    if (stream != null && stream.Length > 0)
                    {
                        using (BinaryReader br = new BinaryReader(stream))
                        {
                            buffer = br.ReadBytes((Int32)stream.Length);
                        }
                    }

                }
                return buffer;

            }
            else { return null; }



        }

       
    }
}
