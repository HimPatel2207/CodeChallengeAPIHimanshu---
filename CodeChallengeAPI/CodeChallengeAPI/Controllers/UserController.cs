using CodeChallengeAPI.Models;
using CodeChallengeAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallengeAPI.Controllers
{
    [ApiController]
    [ReportApiVersions]
    [Route("api/{v:apiVersion}/[controller]")]
    public class UserController : Controller
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public UserController(IAuthenticationRepository authenticationRepository)
        {
                _authenticationRepository = authenticationRepository;
        }
        [HttpGet("UserLogin")]
        public IActionResult GetLoginDetails(string userName, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserDetails loginresult = _authenticationRepository.AuthenticateUser(userName, password);
            if (loginresult.AccessToken == null)
            {
                return BadRequest("Invalid User");
            }
            return Ok(loginresult);
        }
    }
}
