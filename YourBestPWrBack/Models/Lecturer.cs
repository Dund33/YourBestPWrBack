using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace YourBestPWrBack.Models
{
    public class Lecturer
    {
        [BsonId]
        public BsonObjectId Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; } 
        public string Title { get; init; }
        public List<Opinion> Opinions { get; set; }
     
    }
}
