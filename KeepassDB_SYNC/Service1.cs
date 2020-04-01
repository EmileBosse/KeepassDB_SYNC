using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace KeepassDB_SYNC
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Logger.Write(Type.INFO, "KeepassDB_SYNC service is starting.");
            timerCheck.Interval = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;
            timerCheck.Start();
        }

        protected override void OnStop()
        {
            Logger.Write(Type.INFO, "KeepassDB_SYNC service stopped.");
        }

        private void TimerCheck_Tick(object sender, EventArgs e)
        {
            Logger.Write(Type.DEBUG, "*** timer tick ***");
            Analizer.Checkup();
        }
    }
}
