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
    public partial class TrollService : ServiceBase
    {
        public const int RepetitionTimeInMilliseconds = 10*1000;

        public TrollService()
        {
            InitializeComponent();
            
            if (!System.Diagnostics.EventLog.SourceExists("MyTrollSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MyTrollSource", "MyNewTrollLog");
            }
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            this.eventLog = new System.Diagnostics.EventLog();
            this.eventLog.Source = "MyTrollSource";
            this.eventLog.WriteEntry("Troll service started", EventLogEntryType.Information);

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

            Process.Start("mspaint.exe");
        }
    }
}
