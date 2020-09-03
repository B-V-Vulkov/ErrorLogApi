namespace ErrorLogApi.Services.Models.ErrorLog
{
    using System;
    using System.Collections.Generic;

    public class InsertErrorLogServiceModel
    {
        public int ApplicationId { get; set; }

        public DateTime Date { get; set; }

        public int StatusCode { get; set; }

        public string SchoolId { get; set; }

        public string UserId { get; set; }

        public string Exception { get; set; }

        public string InnerException { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string RequestUrl { get; set; }

        public string StackTrace { get; set; }

        public string RequestPeyload { get; set; }

        public IEnumerable<RequestHeaderServiceModel> RequestHeaders { get; set; }
    }
}
