using Microsoft.AspNetCore.Mvc;
using ServiceManager.Interfaces.inbound;

namespace ServiceManager.Api.controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ServiceController : Controller
    {
        private readonly IServiceControll _processService;

        public ServiceController(IServiceControll processService)
            => _processService = processService;

        [HttpGet("{serviceName}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(string serviceName)
            => Ok(_processService.Get(serviceName));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll() 
            => Ok(_processService.GetAll());
    }
}
