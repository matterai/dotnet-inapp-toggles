using matterai.TestService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace matterai.ApiGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomController
    {
        private readonly ILogger<CustomController> _logger;
        private readonly CustomService _service;
        
        public CustomController(ILogger<CustomController> logger, CustomService service)
        {
            _logger = logger;
            _service = service;
        }

        public string Get(string name) => _service.GetGreetings(name);
    }
}