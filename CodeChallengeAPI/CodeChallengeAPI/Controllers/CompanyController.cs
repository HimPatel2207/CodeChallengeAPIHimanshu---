using CodeChallengeAPI.Models;
using CodeChallengeAPI.Repositories;
using CodeChallengeAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace CodeChallengeAPI.Controllers
{
    [ApiController]
    [ReportApiVersions]
    [Route("api/{v:apiVersion}/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyServices _companyServices;

        public CompanyController(ILogger<CompanyController> logger, ICompanyServices companyServices)
        {
            _logger = logger;
            _companyServices = companyServices;
        }

        [Authorize]
        [HttpPost("GetAllCompaniesList")]
        public async Task<IActionResult> GetAllCompaniesList([FromBody] GetList getList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _companyServices.GetCompanies(getList);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error for Get All Companies data");
                return StatusCode(500, "Internal server error = " + ex.Message);
            }
        }
        [Authorize]
        [HttpPost("AddNewCompany")]
        public async Task<IActionResult> AddNewCompany([FromBody] CompanyModel company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = _companyServices.AddCompany(company);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error for Get All Companies data");
                return StatusCode(500, "Internal server error = " + ex.Message);
            }
        }
        [Authorize]
        [HttpGet("GetCompanyById")]
        public async Task<IActionResult> GetCompanyById(int Id)
        {
            try
            {
                if (Id <= 0)
                {
                    return BadRequest(ModelState);
                }
                var result = await Task.FromResult(_companyServices.GetCompanyById(Id));

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error for Get Company ById");
                return StatusCode(500, "Internal server error = " + ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetCompanyByIsin")]
        public async Task<IActionResult> GetCompanyByIsin(string IsIn)
        {
            try
            {
                if (IsIn.IsNullOrEmpty())
                {
                    return BadRequest(ModelState);
                }
                var result = await Task.FromResult(_companyServices.GetCompanyByISIn(IsIn));

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error for Get Company ById");
                return StatusCode(500, "Internal server error = " + ex.Message);
            }
        }

        [Authorize]
        [HttpPut("UpdateCompany")]
        public async Task<IActionResult> UpdateCompany([FromBody] CompanyModel company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = _companyServices.UpdateCompany(company);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Get All Companies data");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize]
        [HttpDelete("DeleteCompany")]
        public async Task<IActionResult> DeleteCompany(int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = _companyServices.DeleteCompany(Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Get All Companies data");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
