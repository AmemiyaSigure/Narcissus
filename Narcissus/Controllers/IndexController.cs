using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Narcissus.ViewModels.Api.Index;

namespace Narcissus.Controllers
{
    [Route("api")]
    [Route("api/[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        private IConfiguration Configuration { get; }

        public IndexController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = new Index()
            {
                ApplicationName = Program.Name,
                ApplicationAuthor = Program.Author,
                ApplicationDescription = Program.Name + " Public API.",
                ApplicationVersion = Program.Version
            };

            if (bool.Parse(Configuration["General:IsShowOwner"]))
            {
                model.ApplicationOwner = Configuration["General:Owner"];
            }
            if (bool.Parse(Configuration["General:IsShowOwnerContact"]))
            {
                model.ApplicationOwnerContact = Configuration["General:OwnerContact"];
            }

            return new JsonResult(model);
        }
    }
}