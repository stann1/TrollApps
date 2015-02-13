namespace WindowsServiceHost
{
    partial class TrollStealthService
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.eventTimer = new System.Windows.Forms.Timer(this.components);
            this.eventLog = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog)).BeginInit();
            // 
            // eventTimer
            // 
            this.eventTimer.Tick += new System.EventHandler(this.eventTimer_Tick);
            // 
            // TrollStealthService
            // 
            this.ServiceName = "TrollService";
            ((System.ComponentModel.ISupportInitialize)(this.eventLog)).EndInit();

        }

        #endregion

        private System.Windows.Forms.Timer eventTimer;
        private System.Diagnostics.EventLog eventLog;
    }
}
