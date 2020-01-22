using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Narcissus.DbModels;
using Narcissus.Models;
using Narcissus.Models.Api.Auth;
using Narcissus.Utilities;
using Narcissus.ViewModels.Api;
using Narcissus.ViewModels.Api.Auth;
using Narcissus.ViewModels.Api.Common;
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
        private IConfiguration Config { get; }

        public AuthController(NarcissusContext context, ILogger logger, IRecaptchaService recaptcha, IConfiguration configuration)
        {
            Db = context;
            Log = logger;
            Recaptcha = recaptcha;
            Config = configuration;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] ModelLogin model)
        {
            // Check request legality.
            if (!ModelState.IsValid)
            {
                return StatusCode(403, new JsonResult(new ViewModelCode403("Model")));
            }

            var recaptcha = await Recaptcha.Validate(Request);
            if (!recaptcha.success)
            {
                return StatusCode(403, new JsonResult(new ViewModelCode403("reCaptcha")));
            }
 
            // Do login. Check password.
            var users = from u in Db.Users
                         where u.Username == model.Username
                               && u.Password == Password.HashPassword(model.Password, u.PasswordSalt)
                         select u;

            var user = users.FirstOrDefault();
            if (user == null)
            {
                return StatusCode(403, new JsonResult(new ViewModelCode403("Password")));
            }

            // Check ip. Unused yet.
            var clientIp = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            /*
            var securities = from s in Db.UsersSecurity
                     where s.Id == user.Id
                     select s;

            var security = securities.FirstOrDefault();
            if (security == null)
            {
                Db.UsersSecurity.Add(new UsersSecurity()
                {
                    Id = user.Id
                });
                Db.SaveChanges();
            }

            if (!string.IsNullOrWhiteSpace(security.LastLoginIp))
            {
                if (security.LastLoginIp != clientIp)
                {

                }
            }
            */

            // Login successful. 
            // Expire expired tokens.
            var timeNow = long.Parse(Time.GetTimeStamp13());

            var tokens = from t in Db.Tokens
                         where t.ExpireTime < timeNow
                         select t;
            foreach (var t in tokens)
            {
                t.Status = 3;
            }
            Db.SaveChanges();

            // Temp expire current user other token.
            tokens = from t in Db.Tokens
                     where t.UserId == user.Id
                        && t.Status == 1
                     select t;
            foreach (var t in tokens)
            {
                t.Status = 2;
            }

            // Generate and save new token.
            var accessToken = Uuid.GetUuid();

            Db.Tokens.Add(new Tokens()
            {
                UserId = user.Id,
                AccessToken = accessToken,
                ClientToken = model.ClientToken,
                ClientIp = clientIp,
                IssueTime = timeNow,
                ExpireTime = timeNow + (int.Parse(Config["Security:TokenExpireDays"]) * 24 * 60 * 60), 
                Status = 1
            });
            Db.SaveChanges();

            // Return results.
            var result = new Login()
            {
                AccessToken = accessToken, 
                ClientToken = model.ClientToken, 
                User = new User()
                {
                    UserId = user.OpenUserId
                }
            };
            return new JsonResult(result);
        }
    }
}