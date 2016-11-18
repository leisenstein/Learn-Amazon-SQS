# Learn-Amazon-SQS

## SQS Set Up

Installation
- Nuget AWSSDK.SQS
- AWS Toolkit for Visual Studio [https://aws.amazon.com/visualstudio/ ]
  - Comes with AWS Explorer
  - UI for Creating Profiles
  - AWS Management Tools

AWS Account Information needed:
  - IAM Account with
    - AWSAccessKey
    - AWSSecretKey
  - Web.config OR App.config, add keys using either method: 
    - AWSAccessKey/AWSSecretKey 
    - AWSProfileName
    
#### I've heard on some issues with SecretKeys that were caused by the secret key having non-alphanumeric characters.  Resolved by regenerating keys until you get one with ONLY alphanumeric characters.


## TestInit
```cs
[TestInitialize]
public void TestInit()
{
    amazonSqsConfig = new AmazonSQSConfig();
    amazonSqsConfig.ServiceURL = queueUrl;
    amazonSqsConfig.RegionEndpoint = RegionEndpoint.USEast1;
    amazonSqsClient = new AmazonSQSClient(amazonSqsConfig);
}
```

### Notes
- Messages are deleted by using their 'Handler'
- Message order is not guaranteed
- Messages can be delivered more than once, so consumer must be able to handle processing the same message more than once
- Visibility Timeout - After a Message is READ from the Queue, it becomes INVISIBLE to other uses for a period of time (Default = 1hr)
- Message Retention - If a Message is not consumed within this time period, it will automatically be deleted (Default = 14 days)
