using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Problem7_FromImageToText
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read the picture name from the app.config file
            var pictureName = ConfigurationManager.AppSettings["FileName1"];

            try
            {
                var img = Image.FromFile(pictureName);
                var resultString = ImageToString(img);
                Console.WriteLine(resultString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();

        }

        /// <summary>
        /// ---Converts an image to an ASCII string---
        /// Transforms the image into a bitmap, parse every 10th pixel of it,
        /// and depending on its brightness, add to the returning string a character
        /// </summary>
        /// <param name="img">The image to be transformed</param>
        /// <returns>A string</returns>
        private static string ImageToString(Image img)
        {
            string pixels = "%&#o*+=-. ";
            var stringToReturn = new StringBuilder();
            var bitMap = new Bitmap(img);
            
            //Parse the image pixel by pixel
            for (int i = 0; i < bitMap.Height; i+=10)
            {
                for (int j = 0; j < bitMap.Width; j+=10)
                {
                    var color = bitMap.GetPixel(i, j);
                    //Check the brightness of the pixel
                    var brightness = Brightness(color);

                    var index = (int)Math.Round((brightness / 256) * pixels.Length - 1);
                    stringToReturn.Append(pixels[index]);
                }
                stringToReturn.Append("\n");
            }


            return stringToReturn.ToString();
        }

        /// <summary>
        /// Get the brightness of a pixel
        /// </summary>
        /// <param name="c">The color of a pixel</param>
        /// <returns>A double from [0,255]</returns>
        private static double Brightness(Color c)
        {
            return (double)Math.Sqrt(
               c.R * c.R * .241 +
               c.G * c.G * .691 +
               c.B * c.B * .068);
        }
    }
}
