namespace ErrorLogApi.RequestModels.ErrorLog
{
    using System.ComponentModel.DataAnnotations;

    public class RequestHeaderRequestModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
