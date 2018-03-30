using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class User
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }

        public User()
        {
            this._id = ObjectId.GenerateNewId();
        }
    }
}
