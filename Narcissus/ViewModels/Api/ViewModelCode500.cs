using Microsoft.AspNetCore.Http;
using System;

namespace Narcissus.ViewModels.Api
{
    public class ViewModelCode500 : ViewModelBase
    {
        private Exception Cause { get; }

        public string Message { get; }
        public string StackTrace { get; }
        public ViewModelCode500 Inner { get; }

        public ViewModelCode500(Exception ex, bool isShowStackTrace)
        {
            Code = StatusCodes.Status500InternalServerError;
            Status = "InternalServerError";

            Cause = ex;
            Message = Cause.Message;
            if (isShowStackTrace)
            {
                StackTrace = Cause.StackTrace;
            }
            if (Cause.InnerException != null)
            {
                Inner = new ViewModelCode500(Cause.InnerException, isShowStackTrace);
            }
        }
    }
}
