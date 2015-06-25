using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScreenSaverCreator.Properties;

namespace ScreenSaverCreator
{
    static class Program
    {
        public const string APPLICATION_NAME = "TrollScreenSaver";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                string firstArgument = args[0].ToLower().Trim();
                string secondArgument = null;

                // Handle cases where arguments are separated by colon.
                // Examples: /c:1234567 or /P:1234567
                if (firstArgument.Length > 2)
                {
                    secondArgument = firstArgument.Substring(3).Trim();
                    firstArgument = firstArgument.Substring(0, 2);
                }
                else if (args.Length > 1)
                    secondArgument = args[1];

                if (firstArgument == "/c")           // Configuration mode
                {
                    // TODO
                    MessageBox.Show(Resources.msg_configuration_na, APPLICATION_NAME,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (firstArgument == "/p")      // Preview mode
                {
                    // TODO
                    Application.Exit();
                }
                else if (firstArgument == "/s")      // Full-screen mode
                {
                    ShowScreenSaver();
                    Application.Run();
                }
                else    // Undefined argument
                {
                    MessageBox.Show(String.Format("Sorry, but the command line argument \"{0}\" is not valid.", firstArgument), APPLICATION_NAME,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else    // No arguments - treat like /c
            {
#if DEBUG
                    ShowScreenSaver();
                    Application.Run();
#else
                MessageBox.Show(Resources.msg_missingArguments, APPLICATION_NAME,
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
#endif
            }            
        }

        private static void ShowScreenSaver()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                ScreenSaverForm screensaver = new ScreenSaverForm(screen.Bounds);
                screensaver.Show();
            }    
        }
    }
}
