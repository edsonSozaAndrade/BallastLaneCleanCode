using Core.Entities;
using Core.Interfaces;

namespace Core.Implementations
{
    public class GetUserByUsername
    {
        private readonly IUserRepository _userRepository;
        public GetUserByUsername(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Execute(string username)
        {
            return await _userRepository.GetByUsername(username);
        }
    }
}
