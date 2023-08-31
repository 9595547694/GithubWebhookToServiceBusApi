using GithubWebhookToServiceBusApi.Adapter.Contracts;
using GithubWebhookToServiceBusApi.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace GithubWebhookToServiceBusApi.BLL.Services
{
    public class ServiceBusService : IServiceBusService
    {
        private readonly IRepositories<JsonObject> _repository;
        public ServiceBusService(IRepositories<JsonObject> repositories)
        {
            _repository = repositories;
        }


        public async Task<string> SendToServiceBus(JsonObject serviceBus)
        {
            try
            {

               return await _repository.SendToTopic(serviceBus);
               
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex);
                return null;
            }
            
        }
    }
}
