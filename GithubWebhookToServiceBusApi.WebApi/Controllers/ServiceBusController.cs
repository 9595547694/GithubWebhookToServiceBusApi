using GithubWebhookToServiceBusApi.BLL.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace GithubWebhookToServiceBusApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceBusController : ControllerBase
    {
        private readonly IServiceBusService _serviceBusService;
        public ServiceBusController(IServiceBusService serviceBusService)
        {
            _serviceBusService = serviceBusService;
        }
        [HttpPost]
        [Route("SentToServiceBus")]
        public async Task<IActionResult> SentToServiceBus(JsonObject GitData)
        {
            try
            {
                await _serviceBusService.SendToServiceBus(GitData);
               return Ok("Added To Service Bus");
            }
            catch (Exception ex)
            {
             throw;
            }
        }
    }
}
