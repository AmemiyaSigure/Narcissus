using Microsoft.AspNetCore.Http;

namespace Narcissus.ViewModels.Api
{
    public class ViewModelBase
    {
        public int Code { get; internal set; } = StatusCodes.Status200OK;
        public string Status { get; internal set; } = "OK";
    }
}
