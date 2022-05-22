using APICrudWithRepository.Contracts;
using APICrudWithRepository.Contracts.Response;
using APICrudWithRepository.Models.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICrudWithRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUser userservice;
        public AccountController(IUser userservice)
        {
            this.userservice = userservice;
        }

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
                    apiresponse.Ok = true;
                    apiresponse.Status = 200;
                    apiresponse.Message = "Login Sucess!";
                    apiresponse.Data = user;
                    apiresponse.Token = "?";
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
    }
}
