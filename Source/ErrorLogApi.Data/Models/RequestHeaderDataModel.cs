namespace ErrorLogApi.Data.Models
{
    using MongoDB.Bson.Serialization.Attributes;

    public class RequestHeaderDataModel
    {
        [BsonRequired]
        public string Name { get; set; }

        [BsonRequired]
        public string Value { get; set; }
    }
}
