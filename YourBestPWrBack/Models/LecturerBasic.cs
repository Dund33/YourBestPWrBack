using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace YourBestPWrBack.Models
{
    public class LecturerBasic
    {
        [System.Runtime.Serialization.IgnoreDataMember]
        [JsonIgnore]
        [BsonId]
        public BsonObjectId Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Title { get; init; }
        public string StringID => Id?.ToString() ?? "Error";
    }
}
