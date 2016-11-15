using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.SQS;
using System.Configuration;
using Amazon;
using System.Configuration;

namespace Learn_Amazon_SQS
{
    public class SqsService
    {
        public string QUEUE { get; set; }
        public string QUEUEURL { get; set; }
        public RegionEndpoint REGION { get; set; }
        public SqsService(string url, string q, RegionEndpoint region)
        {
            
        }
    }
}
