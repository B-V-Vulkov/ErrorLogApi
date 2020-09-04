namespace ErrorLogApi.RequestModels.ErrorLog
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GetErrorLogListRequestModel
    {
        [Required]
        public int ApplicationId { get; set; }

        [Required]
        public DateTime TimeDuration { get; set; }
    }
}
