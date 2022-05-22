using APICrudWithRepository.Contracts;
using APICrudWithRepository.Contracts.Response;
using APICrudWithRepository.Models.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICrudWithRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly IUser userservice;
                
        public AccountController(IUser userservice, IConfiguration config)
        {
            this.userservice = userservice;
            this.config = config;
        }
        private IConfiguration config { get; }

        [HttpPost]
        [Route("SignIn")]

        public IActionResult SignIn(SignInModel model)
        {
            if (model != null)
            {
                var user = userservice.SignIn(model);
                var apiresponse = new APIResponse();
                if(user ==null)
                {
                    //Not found failure
                    apiresponse.Ok = false;
                    apiresponse.Status = 404;
                    apiresponse.Message = "Invalid Login Credentials!";
                    return Ok(apiresponse);
                }
                else
                {
                    // Sucess login
                    string token = GenerateJSONWebToken();
                    apiresponse.Ok = true;
                    apiresponse.Status = 200;
                    apiresponse.Message = "Login Sucess!";
                    apiresponse.Data = user;
                    apiresponse.Token = token;
                    return Ok(apiresponse);
                }
            }
            else
            {
                return BadRequest();
            }


        }
        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp(SignUpModel model)
        {
            if (model != null)
            {
                var user = userservice.SignUp(model);
                var apiresponse = new APIResponse();
                
                
                    // Sucess login
                    apiresponse.Ok = true;
                    apiresponse.Status = 200;
                    apiresponse.Message = "User Registrstion is sucessfully!";
                    apiresponse.Data = user;
                    return Ok(apiresponse);
                
            }
            else
            {
                return BadRequest();
            }

        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
              config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
