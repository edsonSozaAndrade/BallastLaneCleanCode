using Core.Entities;
using Core.Implementations;
using Core.Interfaces;
using Moq;

namespace Tests.Core
{
    public class GetUserByUsernameTests
    {
        [Fact]
        public async Task Execute_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var username = "testuser";
            var user = new User { Username = username };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetByUsername(username)).ReturnsAsync(user);
            var getUserByUsername = new GetUserByUsername(userRepositoryMock.Object);

            // Act
            var result = await getUserByUsername.Execute(username);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(username, result.Username);
        }

        [Fact]
        public async Task Execute_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            var username = "nonexistentuser";
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetByUsername(username)).ReturnsAsync((User)null);
            var getUserByUsername = new GetUserByUsername(userRepositoryMock.Object);

            // Act
            var result = await getUserByUsername.Execute(username);

            // Assert
            Assert.Null(result);
        }
    }
}