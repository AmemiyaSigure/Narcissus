using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Narcissus.DbModels;
using Narcissus.Models;
using Narcissus.Models.Api.Auth;
using Narcissus.Utilities;
using Narcissus.ViewModels.Api;
using NLog;
using reCAPTCHA.AspNetCore;

namespace Narcissus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private NarcissusContext Db { get; }
        private ILogger Log { get; }
        private IRecaptchaService Recaptcha { get; }

        public AuthController(NarcissusContext context, ILogger logger, IRecaptchaService recaptcha)
        {
            Db = context;
            Log = logger;
            Recaptcha = recaptcha;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] ModelLogin model)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new ViewModelCode403("Model"));
            }

            var recaptcha = await Recaptcha.Validate(Request);
            if (!recaptcha.success)
            {
                return new JsonResult(new ViewModelCode403("reCAPTCHA"));
            }

            var result = from u in Db.Users
                         where u.Username == model.Username
                               && u.Password == Password.HashPassword(model.Password, u.PasswordSalt)
                         select u;
        }
    }
}