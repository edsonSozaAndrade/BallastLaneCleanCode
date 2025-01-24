using AutoMapper;
using Core.Entities;
using Infrastructure.Entities;
using Infrastructure.Mappers;

namespace Tests.Infrastructure
{
    public class UpdateUserMapperTests
    {
        private readonly IMapper _mapper;

        public UpdateUserMapperTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<UpdateUserMapper>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void Map_ShouldMapUpdateUserRequestToUser()
        {
            // Arrange
            var request = new UpdateUserRequest
            {
                Id = Guid.NewGuid(),
                Name = "Updated",
                LastName = "User",
                Email = "updateduser@example.com",
                Password = "newpassword"
            };

            // Act
            var user = _mapper.Map<User>(request);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(request.Id, user.Id);
            Assert.Equal(request.Name, user.Name);
            Assert.Equal(request.LastName, user.LastName);
            Assert.Equal(request.Email, user.Email);
        }
    }
}
