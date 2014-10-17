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
        static void Main(string[] args)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string location = System.IO.Path.GetDirectoryName(path);
            try
            {
                CreateTask(location);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            Console.WriteLine("Task created successfully.");
            Console.ReadLine();
        }

        static void CreateTask(string location)
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

                // Create an action that will launch Notepad whenever the trigger fires
                td.Actions.Add(
                    new ExecAction(location + "\\backgroundchanger.exe", "\"" + location + "\\Mexican_troll.bmp" + "\""));
                td.Actions.Add(
                    new ExecAction(location + "\\Bamboleo - Gipsy Kings.mp3"));

                // Register the task in the root folder
                ts.RootFolder.RegisterTaskDefinition(@"TrollApp2", td);

                // Remove the task we just created
                //ts.RootFolder.DeleteTask("Test");
            }
        }
    }
}
