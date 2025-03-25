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
        public IActionResult Post(Ticket contact)
        {

            //Validation classes: 
            //https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-9.0

            //This uses the validation inside Contact.cs
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }


            return Ok("Hello " + contact.name + " from the Tickets Controller - POST");
        }








    }
}
