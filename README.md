# OrderManagement

## Startup
- Fill OrderManagement.API appsettings with your SB connection string and TopicName
- Fill OrderManagement.EventConsumer appsettings with yout SB connection sting, TopicName and SubscriptionName
- If changing url in launch.json in OrderManagement.API - then also change 'ApiUrl' in OrderManagement.Eventconsumer as it has call to API
- Set Multiple startup projects: select OrderManagement.API and OrderManagement.EventConsumer
