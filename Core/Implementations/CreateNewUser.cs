using Core.Entities;
using Core.Interfaces;

namespace Core.Implementations
{
    public class CreateNewUser
    {
        private readonly IUserRepository _userRepository;

        public CreateNewUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Execute(User newUser)
        {
            return await _userRepository.Add(newUser);
        }
    }
}
