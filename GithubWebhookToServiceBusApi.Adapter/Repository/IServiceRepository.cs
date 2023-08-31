using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace GithubWebhookToServiceBusApi.Adapter.Repository
{
     public interface IServiceRepository
      {
         Task<string> SendToTopic(JsonObject topic);
      }
}
