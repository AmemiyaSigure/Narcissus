using Narcissus.ViewModels.Api.Common;

namespace Narcissus.ViewModels.Api.Auth
{
    public class Login : ViewModelBase
    {
        public string AccessToken { get; set; }
        public string ClientToken { get; set; }
        public User User { get; set; }
    }
}
