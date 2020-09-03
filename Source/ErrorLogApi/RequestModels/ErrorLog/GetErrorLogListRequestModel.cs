namespace ErrorLogApi.RequestModels.ErrorLog
{
    using System.ComponentModel.DataAnnotations;

    public class GetErrorLogListRequestModel
    {
        [Required]
        public int ApplicationId { get; set; }
    }
}
