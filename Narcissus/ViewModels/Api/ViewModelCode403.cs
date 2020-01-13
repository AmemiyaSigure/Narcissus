using Microsoft.AspNetCore.Http;

namespace Narcissus.ViewModels.Api
{
    public class ViewModelCode403 : ViewModelBase
    {
        public string Cause { get; set; }

        public ViewModelCode403(string cause)
        {
            Code = StatusCodes.Status403Forbidden;
            Status = "Forbidden";

            Cause = cause;
        }
    }
}
