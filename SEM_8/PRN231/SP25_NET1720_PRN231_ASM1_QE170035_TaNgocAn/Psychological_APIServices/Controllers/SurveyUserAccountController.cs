using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Psychological.Repository.Models;
using Psychological.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Psychological_APIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyUserAccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISurveyUserAccountService _surveyUserAccountService;
        public SurveyUserAccountController(ISurveyUserAccountService surveyUserAccountService, IConfiguration configuration)
        {
            _surveyUserAccountService = surveyUserAccountService;
            _configuration = configuration;
        }
        // GET: api/<SurveyUserAccountController>
        [HttpGet]
        public async Task<IEnumerable<UserAccount>> Get()
        {
            return await _surveyUserAccountService.GetAll();
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginReqeust request)
        {
            var user = _surveyUserAccountService.Authenticate(request.UserName, request.Password);

            if (user == null || user.Result == null)
                return Unauthorized();

            var token = GenerateJSONWebToken(user.Result);

            return Ok(token);
        }

        private string GenerateJSONWebToken(UserAccount systemUserAccount)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"]
                    , _configuration["Jwt:Audience"]
                    , new Claim[]
                    {
                new(ClaimTypes.Name, systemUserAccount.UserName),
                //new(ClaimTypes.Email, systemUserAccount.Email),
                new(ClaimTypes.Role, systemUserAccount.RoleId.ToString()),
                    },
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

        public sealed record LoginReqeust(string UserName, string Password);

        // GET api/<SurveyUserAccountController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "1, 2")]
        public async Task<UserAccount> Get(int id)
        {
            return await _surveyUserAccountService.GetById(id);
        }

        // POST api/<SurveyUserAccountController>
        [HttpPost]
        [Authorize(Roles = "1, 2")]
        public async Task<int> Post(UserAccount userAccount)
        {
            return await _surveyUserAccountService.Create(userAccount);
        }

        // PUT api/<SurveyUserAccountController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "1, 2")]
        public async Task<int> Put(UserAccount userAccount)
        {
            return await _surveyUserAccountService.Update(userAccount);
        }

        // DELETE api/<SurveyUserAccountController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public async Task<bool> Delete(int id)
        {
             return await _surveyUserAccountService.Delete(id);
        }
    }
}
