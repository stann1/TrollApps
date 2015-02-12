using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.TaskScheduler;
using TaskScheduler.Properties;
using System.Configuration;

namespace TaskScheduler
{
    class Program
    {
        private static string _applicationPath;

        static void Main(string[] args)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            _applicationPath = System.IO.Path.GetDirectoryName(path);

            try
            {
                CreateTask();
            }
            catch (Exception ex)
            {
                throw;
            }
            Console.WriteLine("Task created successfully.");
            Console.ReadLine();
        }

        private static void CreateTask()
        {
            double triggerOffset = double.Parse(ConfigurationManager.AppSettings["initialOffsetMinutes"]);
            double intervalRepeat = double.Parse(ConfigurationManager.AppSettings["repeatIntervalMinutes"]);

            using (TaskService ts = new TaskService())
            {
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Dedicated to trolling you";

                // Create a trigger that will fire the task at this time every other day
                TimeTrigger trigger = new TimeTrigger(DateTime.Now + TimeSpan.FromMinutes(triggerOffset));
                trigger.Repetition.Interval = TimeSpan.FromMinutes(intervalRepeat);
                td.Triggers.Add(trigger);

                // Create actions that will launch whenever the trigger fires
                //td.Actions.Add(
                //    new ExecAction(GetExecutingFilePath("backgroundchanger.exe"), GetBackgroundPicAsArgument("Mexican_troll.bmp")));
                //td.Actions.Add(new ExecAction(GetExecutingFilePath("Bamboleo - Gipsy Kings.mp3")));
                td.Actions.Add(new ExecAction(GetExecutingFilePath("screensavercreator.exe"), "/s"));
                
                
                // Register the task in the root folder
                ts.RootFolder.RegisterTaskDefinition(@"TrollApp2.1", td);

                // Remove the task we just created
                //ts.RootFolder.DeleteTask("Test");
            }
        }

        private static string GetExecutingFilePath(string fileName)
        {
            return String.Format("{0}\\{1}", _applicationPath, fileName);
        }

        private static string GetBackgroundPicAsArgument(string fileName)
        {
            return String.Format("\"{0}\\{1}\"", _applicationPath, fileName);
        }
    }
}
