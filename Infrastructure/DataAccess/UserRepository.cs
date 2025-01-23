using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public Task<User> Add(User newUser)
        {
            throw new NotImplementedException();
        }

        public Task<User> Delete(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
