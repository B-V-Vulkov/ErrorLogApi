namespace ErrorLogApi.Data.Models
{
    using System;
    using MongoDB.Bson.Serialization.Attributes;

    public class UserDataModel
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonRequired]
        public string Username { get; set; }

        [BsonRequired]
        public string HashedPassword { get; set; }

        [BsonRequired]
        public string FirstName { get; set; }

        [BsonRequired]
        public string LastName { get; set; }
    }
}
