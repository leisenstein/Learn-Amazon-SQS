using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon;
using System.Configuration;

namespace Learn_Amazon_SQS
{
    static class Program
    {
        public static string QUEUE { get; set; }
        public static string QUEUEURL { get; set; }
        public static RegionEndpoint REGION { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new lblOutput());
            GetSettings();
        }

        static void GetSettings()
        {
            QUEUE = ConfigurationManager.AppSettings.Get("queue-name");
            QUEUEURL = ConfigurationManager.AppSettings.Get("queue-url");
            REGION = RegionEndpoint.USEast1;
        }
    }
}
