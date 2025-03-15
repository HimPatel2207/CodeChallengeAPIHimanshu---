using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;


namespace CodeChallengeAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ApplicationDetailsController : Controller
    {
        private readonly ILogger<ApplicationDetailsController> _logger;


        public ApplicationDetailsController(ILogger<ApplicationDetailsController> logger)
        {
            _logger = logger;

        }

        [HttpGet]
        public IActionResult Get()
        {
            //var apiVersion = _provider.ApiVersionDescriptions.FirstOrDefault()?.ApiVersion.ToString() ?? "1.0";
            var applicationData = new ApiDetails()
            {
                Name = "CodeChallengeAPI",
                Version = "5.0",
                Description = "This is a code challenge API Developed by Himanshu Patel",
                Contact = "0892055536",
                License = "005478215151"
            };
            return Ok(applicationData);
        }
    }
}
