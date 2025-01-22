using Core.Entities;
using Core.Interfaces;

namespace Core.Implementations
{
    public class GetUser
    {
        private readonly IUserRepository _userRepository;

        public GetUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Execute(Guid userId)
        {
            return await _userRepository.GetById(userId);
        }
    }
}
