using System.Text.Json;
using Azure.Storage.Queues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketHub;

namespace TicketHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {

        private readonly ILogger<TicketsController> _logger;
        private readonly IConfiguration _configuration;


        public TicketsController(ILogger<TicketsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from the Tickets Controller - GET");
        }



        [HttpPost]
        public async Task<IActionResult> Post(Ticket contact)
        {

            //Validation classes: 
            //https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-9.0

            //This uses the validation inside Ticket.cs
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            //
            // Post content to queue
            //

            string queueName = "tickets";

            // Get connection string from secrets.json
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error was encountered");
            }

            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // serialize an object to json
            string message = JsonSerializer.Serialize(contact);

            // send string message to queue
            await queueClient.SendMessageAsync(message);

            //await queueClient.SendMessageAsync("Hello from the API App!");




            return Ok("Sucess - message posted to Storage Queue");
        }








    }
}
