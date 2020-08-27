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
        public DateTime ErrorDateTime { get; set; }

        [BsonRequired]
        public string Url { get; set; }

        [BsonRequired]
        public string SchoolId { get; set; }

        [BsonRequired]
        public string UserId { get; set; }

        [BsonRequired]
        public string ControllerName { get; set; }

        [BsonRequired]
        public string ActionName { get; set; }

        [BsonRequired]
        public string ExceptionMessage { get; set; }

        [BsonRequired]
        public string InnerExceptionMessage { get; set; }

        [BsonRequired]
        public string StackTrace { get; set; }

        [BsonRequired]
        public string RequestPeyload { get; set; }

        [BsonRequired]
        public IEnumerable<RequestHeaderDataModel> RequestHeaders { get; set; }
    }
}
