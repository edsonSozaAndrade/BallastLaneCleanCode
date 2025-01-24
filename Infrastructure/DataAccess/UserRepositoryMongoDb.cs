using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;
using MongoDB.Driver;

namespace Infrastructure.DataAccess
{
    public class UserRepositoryMongoDb : IUserRepository
    {
        private readonly IMongoCollection<User> _usersCollection;

        public UserRepositoryMongoDb(MongoContext context)
        {
            _usersCollection = context.GetCollection<User>("Users");
        }

        public async Task<User> Add(User newUser)
        {
            await _usersCollection.InsertOneAsync(newUser);
            return null;
        }

        public async Task<User> Delete(Guid userId)
        {
            await _usersCollection.DeleteOneAsync(u => u.Id == userId);
            return null;
        }

        public async Task<List<User>> GetAll()
        {
            return await _usersCollection.Find(u => true).ToListAsync();
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _usersCollection.Find(u => u.Username == username).FirstOrDefaultAsync();
        }

        public async Task<User> GetById(Guid userId)
        {
            return await _usersCollection.Find(u => u.Id == userId).FirstOrDefaultAsync();
        }

        public async Task<User> Update(User user)
        {
            await _usersCollection.ReplaceOneAsync(u => u.Id == user.Id, user);
            return null;
        }
    }
}
