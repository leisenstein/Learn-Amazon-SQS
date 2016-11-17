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

namespace Learn_Amazon_SQS
{
    public class SqsService
    {
        public string QUEUEPREFIX { get; set; }
        public string QUEUEURL { get; set; }
        public RegionEndpoint REGION { get; set; }
        private AmazonSQSConfig amazonSqsConfig;
        private AmazonSQSClient amazonSqsClient;

        public SqsService(string url, string q, RegionEndpoint region)
        {
            QUEUEPREFIX = q;
            QUEUEURL = url;
            REGION = region;

            amazonSqsConfig = new AmazonSQSConfig();
            amazonSqsConfig.ServiceURL = QUEUEURL;
            amazonSqsConfig.RegionEndpoint = REGION;
            amazonSqsClient = new AmazonSQSClient(amazonSqsConfig);
        }









        

        public void ListQueues()
        {
            var providerQueuePrefix = QUEUEPREFIX;
            var sendMessageRequest = new SendMessageRequest();
            sendMessageRequest.QueueUrl = amazonSqsConfig.ServiceURL;
            sendMessageRequest.MessageBody = "{TEST: Message}";

            var listOfQueues = amazonSqsClient.ListQueues(providerQueuePrefix);
            var queues = listOfQueues.QueueUrls;
        }

        

        public void SendQueueMessage(string message)
        {
            var providerQueuePrefix = QUEUEPREFIX;
            var sendMessageRequest = new SendMessageRequest();
            sendMessageRequest.QueueUrl = amazonSqsConfig.ServiceURL;
            sendMessageRequest.MessageBody = message;

            var response = amazonSqsClient.SendMessage(sendMessageRequest);
            
        }

        

        public void TestSendQueueObject()
        {
            //LocationModel lm = new LocationModel
            //{
            //    Latitude = 43.2321,
            //    Longitude = -79.8382
            //};
            //SendMessageRequest request = new SendMessageRequest(QUEUEURL, lm.ToJson());
            //var response = amazonSqsClient.SendMessage(request);

            
        }

        

        public void ReadFromQueue()
        {
            ReceiveMessageRequest request = new ReceiveMessageRequest(QUEUEURL);
            request.MaxNumberOfMessages = 1;

            var response = amazonSqsClient.ReceiveMessage(request);
            
        }

        

        public void DeleteFromQueue(string handle)
        {
            DeleteMessageRequest request = new DeleteMessageRequest(QUEUEURL, handle);

            var response = amazonSqsClient.DeleteMessage(request);

        }

    }
}
