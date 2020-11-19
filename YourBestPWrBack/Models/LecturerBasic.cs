using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

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
