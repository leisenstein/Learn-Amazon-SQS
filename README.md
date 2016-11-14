# Learn-Amazon-SQS

## SQS Set Up

Installation
- Nuget AWSSDK.Core
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
