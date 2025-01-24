using Core.Entities;
using Core.Implementations;
using Core.Interfaces;
using Moq;

namespace Tests.Core
{
    public class CreateNewUserTests
    {
        [Fact]
        public async Task Execute_ShouldAddUser()
        {
            // Arrange
            var newUser = new User { Username = "newuser" };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.Add(newUser)).ReturnsAsync(newUser);
            var createNewUser = new CreateNewUser(userRepositoryMock.Object);

            // Act
            var result = await createNewUser.Execute(newUser);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newUser.Username, result.Username);
            userRepositoryMock.Verify(repo => repo.Add(newUser), Times.Once);
        }
    }
}