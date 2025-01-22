using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(Guid userId);
        Task<User> GetAll();
        Task<User> Add(User newUser);
        Task<User> Update(User user);
        Task<User> Delete(Guid userId);
    }
}
