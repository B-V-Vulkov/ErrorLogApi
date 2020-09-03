namespace ErrorLogApi.RequestModels.ErrorLog
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class InsertErrorLogRequestModel
    {
        [Required]
        public int ApplicationId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int StatusCode { get; set; }

        [Required]
        public string SchoolId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Exception { get; set; }

        public string InnerException { get; set; }

        [Required]
        public string ControllerName { get; set; }

        [Required]
        public string ActionName { get; set; }

        [Required]
        public string RequestUrl { get; set; }

        [Required]
        public string StackTrace { get; set; }

        public string RequestPeyload { get; set; }

        public IEnumerable<RequestHeaderRequestModel> RequestHeaders { get; set; }
    }
}
