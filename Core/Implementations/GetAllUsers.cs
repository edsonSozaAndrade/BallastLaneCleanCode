using Core.Entities;
using Core.Interfaces;

namespace Core.Implementations
{
    public class GetAllUsers
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsers(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Execute()
        {
            return await _userRepository.GetAll();
        }
    }
}
