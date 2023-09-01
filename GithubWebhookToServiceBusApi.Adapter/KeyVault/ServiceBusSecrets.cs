﻿using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubWebhookToServiceBusApi.Adapter.KeyVault
{
    public class ServiceBusSecrets
    {
        string KeyVaultUri = "https://javaazurekeyvault.vault.azure.net/";
        public string GetServicebusConnectionString()
        {

            var KeyVaultSecret= new SecretClient(new Uri(KeyVaultUri),new DefaultAzureCredential());
            var ConnectionString = KeyVaultSecret.GetSecret("servicebusconnectionstring");
            return ConnectionString.Value.Value;

        }

        public string GetTopicName()
        {
            var KeyVaultSecret = new SecretClient(new Uri(KeyVaultUri), new DefaultAzureCredential());
            var TopicName = KeyVaultSecret.GetSecret("topicname");
            return TopicName.Value.Value;
        }
    }
}
