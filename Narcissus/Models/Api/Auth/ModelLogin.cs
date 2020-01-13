using Narcissus.Utilities.ModelAttributes;
using System.ComponentModel.DataAnnotations;

namespace Narcissus.Models.Api.Auth
{
    public class ModelLogin
    {
        [Required]
        [NotChinese]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string GoogleToken { get; set; }
    }
}
