using Core.Entities;
using Core.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApi.Entities;

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

        public UsersController(CreateNewUser createNewUser, GetAllUsers getAllUsers, GetUser getUser, UpdateExistingUser updateExistingUser, DeleteExistingUser deleteUser)
        {
            _createNewUser = createNewUser;
            _getAllUsers = getAllUsers;
            _getUser = getUser;
            _updateExistingUser = updateExistingUser;
            _deleteUser = deleteUser;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewUser(NewUserRequest request)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email
            };
            var createdUser = await _createNewUser.Execute(user);
            return Ok(createdUser);
        }
    }
}
