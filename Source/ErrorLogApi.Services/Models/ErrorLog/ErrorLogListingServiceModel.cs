namespace ErrorLogApi.Services.Models.ErrorLog
{
    using System;

    public class ErrorLogListingServiceModel
    {
        public Guid ErrorLogId { get; set; }

        public int StatusCode { get; set; }

        public string SchoolId { get; set; }

        public string UserId { get; set; }

        public string Exception { get; set; }

        public DateTime Date { get; set; }
    }
}
