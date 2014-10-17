using System;

namespace BackgroundChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            //Wallpaper.GetCurrent();

            if (args.Length > 0)
            {
                string imgPath = args[0];
                Wallpaper.Set(imgPath, Wallpaper.Style.Centered);
            }
            else
            {
                Console.WriteLine("You must provide an image path");
            }
        }
    }
}
