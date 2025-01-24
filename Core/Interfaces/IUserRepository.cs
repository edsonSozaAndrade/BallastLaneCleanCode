using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(Guid userId);
        Task<List<User>> GetAll();
        Task<User> Add(User newUser);
        Task<User> Update(User user);
        Task<User> Delete(Guid userId);
        Task<User> GetByUsername(string username);
    }
}
