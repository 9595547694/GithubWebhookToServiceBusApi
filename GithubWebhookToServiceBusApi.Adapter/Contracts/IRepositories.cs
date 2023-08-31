using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubWebhookToServiceBusApi.Adapter.Contracts
{
    public interface IRepositories<T>
    {
        public Task<string> SendToTopic(T topic);
    }
}
