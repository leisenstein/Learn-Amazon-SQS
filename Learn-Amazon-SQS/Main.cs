using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon;
using Newtonsoft.Json;

namespace Learn_Amazon_SQS
{
    public partial class lblOutput : Form
    {
        public static string QUEUE { get; set; }
        public static string QUEUEURL { get; set; }
        public static RegionEndpoint REGION { get; set; }

        public lblOutput()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var msg = txtInput.Text.Trim();
            if (msg.Length < 0)
                txtInput.Text += System.Environment.NewLine + "Error: No Message";
            GetSettings();
            SqsService svcService = new SqsService(QUEUEURL, QUEUE, REGION);
            var result = svcService.SendQueueMessage(msg);

            txtOutput.Text += System.Environment.NewLine + "Result: " + result;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            GetSettings();
            SqsService svcService = new SqsService(QUEUEURL, QUEUE, REGION);
            var result = svcService.ReadFromQueue();
            var jsonResult = JsonConvert.SerializeObject(result);
            txtOutput.Text += System.Environment.NewLine + "Result: " + jsonResult;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            GetSettings();
            SqsService svcService = new SqsService(QUEUEURL, QUEUE, REGION);
            var result = svcService.DeleteFromQueue(txtInput.Text);

            txtOutput.Text += System.Environment.NewLine + "Deleted: " + result;
        }

        private void btnPurge_Click(object sender, EventArgs e)
        {
            GetSettings();
            SqsService svcService = new SqsService(QUEUEURL, QUEUE, REGION);
            var result = svcService.PurgeQueue();

            txtOutput.Text += System.Environment.NewLine + "Purged: " + result;
        }



        static void Process()
        {
            GetSettings();
            SqsService svcService = new SqsService(QUEUEURL, QUEUE, REGION);

            var listQueues = svcService.ListQueues();
            var sm = svcService.SendQueueMessage("TEST:" + DateTime.Now.ToShortDateString());
            var so = svcService.SendQueueObject(new LocationModel
            {
                Latitude = 45.33422,
                Longitude = -89.99533
            });

            var rd = svcService.ReadFromQueue();
            var del = svcService.DeleteFromQueue(rd.ReceiptHandle);
        }

        static void GetSettings()
        {
            QUEUE = ConfigurationManager.AppSettings.Get("queue-name");
            QUEUEURL = ConfigurationManager.AppSettings.Get("queue-url");
            REGION = RegionEndpoint.USEast1;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Process();
        }
    }
}
