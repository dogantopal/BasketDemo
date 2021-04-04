using System;
using System.Collections.Generic;
using System.Net;

namespace Application
{
    public class ServiceException : Exception
    {
        public HttpStatusCode Code { get; set; }
        public string ErrorMessage { get; set; }

        public ServiceException(HttpStatusCode code, string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.Code = code;
        }
    }
}
