using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.SQS;
using System.Configuration;
using Amazon;
using System.Configuration;
using System.Net;
using Amazon.SQS.Model;
using Newtonsoft.Json;

namespace Learn_Amazon_SQS
{
    public class SqsService
    {
        private string QUEUEPREFIX { get; set; }
        private string QUEUEURL { get; set; }
        private RegionEndpoint REGION { get; set; }
        private AmazonSQSConfig amazonSqsConfig;
        private AmazonSQSClient amazonSqsClient;

        public SqsService(string url, string q, RegionEndpoint region)
        {
            QUEUEPREFIX = q;
            QUEUEURL = url;
            REGION = region;

            amazonSqsConfig = new AmazonSQSConfig();
            amazonSqsConfig.ServiceURL = QUEUEURL;  // This does not set it properly, its still NULL
            amazonSqsConfig.RegionEndpoint = REGION;
            amazonSqsClient = new AmazonSQSClient(amazonSqsConfig);
        }

        
        // works
        public List<string> ListQueues()
        {
            var providerQueuePrefix = QUEUEPREFIX;
            var sendMessageRequest = new SendMessageRequest();
            sendMessageRequest.QueueUrl = QUEUEURL;
            sendMessageRequest.MessageBody = "{TEST: Message}";
            
            var response = amazonSqsClient.ListQueues(providerQueuePrefix);

            if (response.HttpStatusCode != HttpStatusCode.OK)
                return null;

            var result = response.QueueUrls;
            return result;
        }

        

        public string SendQueueMessage(string message)
        {
            var providerQueuePrefix = QUEUEPREFIX;
            var sendMessageRequest = new SendMessageRequest();
            sendMessageRequest.QueueUrl = QUEUEURL;//amazonSqsConfig.ServiceURL; //null
            sendMessageRequest.MessageBody = message;

            var response = amazonSqsClient.SendMessage(sendMessageRequest);

            if (response.HttpStatusCode != HttpStatusCode.OK)
                return null;

            var result = response.MessageId;
            return result;
        }

        

        public string SendQueueObject(object o)
        {
            var oJson = JsonConvert.SerializeObject(o);
            SendMessageRequest request = new SendMessageRequest(QUEUEURL, oJson);
            var response = amazonSqsClient.SendMessage(request);

            if (response.HttpStatusCode != HttpStatusCode.OK)
                return null;

            var result = response.MessageId;
            return result;
        }



        public Message ReadFromQueue()
        {
            ReceiveMessageRequest request = new ReceiveMessageRequest(QUEUEURL);
            request.MaxNumberOfMessages = 1;

            var response = amazonSqsClient.ReceiveMessage(request);
            if (response.HttpStatusCode != HttpStatusCode.OK || response.Messages.Count == 0)
                return null;

            var result = response.Messages[0];
            return result;
        }


        public bool DeleteFromQueue(string handle)
        {
            bool result = false;
            DeleteMessageRequest request = new DeleteMessageRequest(QUEUEURL, handle);
            
            var response = amazonSqsClient.DeleteMessage(request);
            result = response.HttpStatusCode == HttpStatusCode.OK;
            return result;
        }


        public bool PurgeQueue()
        {
            bool result = false;
            PurgeQueueRequest request = new PurgeQueueRequest();
            request.QueueUrl = QUEUEURL;
            var response = amazonSqsClient.PurgeQueue(request);
            result = response.HttpStatusCode == HttpStatusCode.OK;
            return result;
        }
    }
}
