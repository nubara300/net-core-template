using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreTemplateREST.Controllers  // namespace promeniti obavezno
{
    public class ExampleController : BaseController  // svaki api nasledjuje base controlerr
    {
        private readonly ILogger<ExampleController> _logger;

        public ExampleController(ILogger<ExampleController> logger) : base(logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult PingServer()
        {
            _logger.LogInformation("Server pinged");
            return Ok();
        }

    }
}
