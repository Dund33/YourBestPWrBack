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
        public BsonObjectId BsonId { get; init; }
        public int Id { get; set; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Title { get; init; }
        public string StringID => BsonId?.ToString() ?? "Error";
    }
}
