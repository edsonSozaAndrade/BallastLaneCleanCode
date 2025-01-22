using Core.Entities;
using Core.Interfaces;

namespace Core.Implementations
{
    public class UpdateExistingUser
    {
        private readonly IUserRepository _userRepository;
        public UpdateExistingUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Execute(User updatedUser)
        {
            return await _userRepository.Update(updatedUser);
        }
    }
}
