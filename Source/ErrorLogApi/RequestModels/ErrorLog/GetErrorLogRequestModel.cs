namespace ErrorLogApi.RequestModels.ErrorLog
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GetErrorLogRequestModel
    {
        [Required]
        public Guid ErrorLogId { get; set; }
    }
}
