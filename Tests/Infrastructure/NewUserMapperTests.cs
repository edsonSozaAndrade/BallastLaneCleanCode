using AutoMapper;
using Core.Entities;
using Infrastructure.Entities;
using Infrastructure.Mappers;

namespace Tests.Infrastructure
{
    public class NewUserMapperTests
    {
        private readonly IMapper _mapper;

        public NewUserMapperTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<NewUserMapper>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void Map_ShouldMapNewUserRequestToUser()
        {
            // Arrange
            var request = new NewUserRequest
            {
                Username = "newuser",
                Name = "New",
                LastName = "User",
                Email = "newuser@example.com",
                Password = "password"
            };

            // Act
            var user = _mapper.Map<User>(request);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(request.Username, user.Username);
            Assert.Equal(request.Name, user.Name);
            Assert.Equal(request.LastName, user.LastName);
            Assert.Equal(request.Email, user.Email);
        }
    }
}