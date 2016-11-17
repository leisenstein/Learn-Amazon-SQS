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
        

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new lblOutput());
            
        }





        
        
    }
}
