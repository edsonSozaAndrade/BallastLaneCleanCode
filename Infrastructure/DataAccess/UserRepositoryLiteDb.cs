using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.DataAccess
{
    public class UserRepositoryLiteDb : IUserRepository
    {
        private readonly LiteContext _context;

        public UserRepositoryLiteDb(LiteContext context)
        {
            _context = context;
        }

        public async Task<User> GetById(Guid userId)
        {
            var collection = _context.GetCollection<User>("Users");
            return await Task.FromResult(collection.FindOne(u => u.Id == userId));
        }

        public async Task<List<User>> GetAll()
        {
            var collection = _context.GetCollection<User>("Users");
            return await Task.FromResult(collection.FindAll().ToList());
        }

        public async Task<User> Add(User newUser)
        {
            var collection = _context.GetCollection<User>("Users");
            collection.Insert(newUser);
            await Task.CompletedTask;
            return null;
        }

        public async Task<User> Update(User user)
        {
            var collection = _context.GetCollection<User>("Users");
            collection.Update(user);
            await Task.CompletedTask;
            return null;
        }

        public async Task<User> Delete(Guid userId)
        {
            var collection = _context.GetCollection<User>("Users");
            collection.Delete(userId);
            await Task.CompletedTask;
            return null;
        }
    }
}
