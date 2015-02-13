using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceHost
{
    public partial class TrollStealthService : ServiceBase
    {
        public const int RepetitionTimeInMilliseconds = 3600*1000;

        public TrollStealthService()
        {
            InitializeComponent();
            this.eventLog = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MyTrollSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MyTrollSource", "MyNewTrollLog");
            }
            this.eventLog.Source = "MyTrollSource";
            this.eventLog.Log = "MyNewTrollLog";
        }

        protected override void OnStart(string[] args)
        {
            this.eventLog.WriteEntry("Troll service started");
            eventTimer.Interval = RepetitionTimeInMilliseconds;
            eventTimer.Tick += eventTimer_Tick;
            eventTimer.Start();
        }

        protected override void OnStop()
        {
            this.eventLog.WriteEntry("Troll service stopped");
        }

        private void eventTimer_Tick(object sender, EventArgs e)
        {
            this.eventLog.WriteEntry("Initiate troll service timer event");

            // TODO: Put the troll code here
        }
    }
}
