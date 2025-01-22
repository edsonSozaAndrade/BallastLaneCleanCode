using Core.Entities;
using Core.Interfaces;

namespace Core.Implementations
{
    public class DeleteExistingUser
    {
        private readonly IUserRepository _userRepository;

        public DeleteExistingUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Execute(Guid userId)
        {
            return await _userRepository.Delete(userId);
        }
    }
}
