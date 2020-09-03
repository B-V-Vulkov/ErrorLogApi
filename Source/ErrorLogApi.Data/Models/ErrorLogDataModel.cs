namespace ErrorLogApi.Data.Models
{
    using System;
    using System.Collections.Generic;
    using MongoDB.Bson.Serialization.Attributes;

    public class ErrorLogDataModel
    {
        public ErrorLogDataModel()
        {
            this.RequestHeaders = new List<RequestHeaderDataModel>();
        }

        [BsonId]
        public Guid Id { get; set; }

        [BsonRequired]
        public int ApplicationId { get; set; }

        [BsonRequired]
        public DateTime Date { get; set; }

        [BsonRequired]
        public int StatusCode { get; set; }

        [BsonRequired]
        public string SchoolId { get; set; }

        [BsonRequired]
        public string UserId { get; set; }

        [BsonRequired]
        public string Exception { get; set; }

        public string InnerException { get; set; }

        [BsonRequired]
        public string ControllerName { get; set; }

        [BsonRequired]
        public string ActionName { get; set; }

        [BsonRequired]
        public string RequestUrl { get; set; }

        [BsonRequired]
        public string StackTrace { get; set; }

        public string RequestPeyload { get; set; }

        public IEnumerable<RequestHeaderDataModel> RequestHeaders { get; set; }
    }
}
