using Azure.Messaging.ServiceBus;
using Azure.Security.KeyVault.Secrets;
using GithubWebhookToServiceBusApi.Adapter.Contracts;
using GithubWebhookToServiceBusApi.Adapter.KeyVault;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace GithubWebhookToServiceBusApi.Adapter.Repository
{
    public class ServiceRepository : IRepositories<JsonObject>
    {
       private readonly ServiceBusSecrets _secrets;

        public ServiceRepository(ServiceBusSecrets secrets)
        {
            _secrets = secrets;
        }
        public async Task<string> SendToTopic(JsonObject topic)
        {
            //ServiceBusSecrets _secrets = new ServiceBusSecrets();
            try
            {
                var connectionstring = _secrets.GetServicebusConnectionString();
                var topicName = _secrets.GetTopicName();
                ServiceBusClient serviceBusClient = new ServiceBusClient(connectionstring);
                ServiceBusSender serviceBusSender = serviceBusClient.CreateSender(topicName);
                ServiceBusMessageBatch serviceBusMessageBatch = await serviceBusSender.CreateMessageBatchAsync();
                ServiceBusMessage serviceBusMessage = new ServiceBusMessage(JsonConvert.SerializeObject(topic, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    }));
                serviceBusMessage.ContentType = "application/json";
                serviceBusMessageBatch.TryAddMessage(serviceBusMessage);
                await serviceBusSender.SendMessagesAsync(serviceBusMessageBatch);
                await serviceBusSender.DisposeAsync();
                await serviceBusClient.DisposeAsync();
                return "Data Send To Topic";
            }

            catch (Exception ex)
            {

                return "Something Went Wrong";

            }
            
        }
    }

}
