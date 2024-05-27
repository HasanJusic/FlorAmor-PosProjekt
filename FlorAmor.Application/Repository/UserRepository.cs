using FlorAmor.Application.Data;
using FlorAmor.Application.Model;
using MongoDB.Driver;
using System.Linq;

namespace FlorAmor.Application.Repository
{
    public class UserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(MongoDBContext context)
        {
            _users = context.Users;
        }

        public User GetUserByEmail(string email)
        {
            return _users.Find(u => u.Email == email).FirstOrDefault();
        }

        public bool ValidatePassword(string inputPassword, string storedPassword)
        {
            // Assuming plain text passwords for simplicity. 
            // Replace with hashing logic in production.
            return inputPassword == storedPassword;
        }

        public void CreateUser(User user)
        {
            _users.InsertOne(user);
        }

        public bool DoesUserExistByEmail(string email)
        {
            return _users.Find(u => u.Email == email).Any();
        }
    }
}
