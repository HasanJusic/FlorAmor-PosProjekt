using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace FlorAmor.Application.Model {
    public class User {
        
        [Key]
        [BsonId] public Guid _id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public User() {
        }

        public User(string email, string password, string vorname, string nachname) {
            _id = Guid.NewGuid();
            Email = email;
            Password = password;
            Vorname = vorname;
            Nachname = nachname;
        }
    }
}
