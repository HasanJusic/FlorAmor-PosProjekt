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

        public bool ValidatePassword(string inputPassword, string storedPassword) {
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
        
        public User GetUserById(Guid userId) {
            return _users.Find(u => u._id == userId).FirstOrDefault();
        }
        
        public async Task<bool> DeleteUserbyid(Guid subjectId) {
            try {
                var deleteResult = await _users.DeleteOneAsync(x => x._id == subjectId);
                return deleteResult.DeletedCount > 0;
            } catch (Exception ex) {
                return false;
            }
        }
    }
}
