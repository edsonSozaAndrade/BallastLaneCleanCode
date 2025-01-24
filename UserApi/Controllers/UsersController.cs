using AutoMapper;
using Core.Entities;
using Core.Implementations;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private readonly CreateNewUser _createNewUser;
        private readonly GetAllUsers _getAllUsers;
        private readonly GetUser _getUser;
        private readonly UpdateExistingUser _updateExistingUser;
        private readonly DeleteExistingUser _deleteUser;

        private readonly IMapper _mapper;

        public UsersController(CreateNewUser createNewUser,
                            GetAllUsers getAllUsers,
                            GetUser getUser,
                            UpdateExistingUser updateExistingUser,
                            DeleteExistingUser deleteUser,                            
                            IMapper mapper)
        {
            _createNewUser = createNewUser;
            _getAllUsers = getAllUsers;
            _getUser = getUser;
            _updateExistingUser = updateExistingUser;
            _deleteUser = deleteUser;           
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var createdUser = await _getUser.Execute(userId);
            return Ok(createdUser);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            var allUsers = await _getAllUsers.Execute();
            return Ok(allUsers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewUser(NewUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            var createdUser = await _createNewUser.Execute(user);
            return Ok(createdUser);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExistingUser(UpdateUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            var updatedUser = await _updateExistingUser.Execute(user);
            return Ok(updatedUser);
        }

        [HttpDelete]
        [Route("/{userId}")]
        public async Task<IActionResult> DeleteExistingUser(Guid userId)
        {
            var deletedUser = await _deleteUser.Execute(userId);
            return Ok(deletedUser);
        }        
    }
}
