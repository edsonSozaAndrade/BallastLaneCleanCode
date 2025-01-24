using Core.Entities;
using Core.Implementations;
using Core.Interfaces;
using Moq;

namespace Tests.Core
{
    public class GetUserTests
    {
        [Fact]
        public async Task Execute_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new User { Id = userId };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetById(userId)).ReturnsAsync(user);
            var getUser = new GetUser(userRepositoryMock.Object);

            // Act
            var result = await getUser.Execute(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
        }

        [Fact]
        public async Task Execute_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetById(userId)).ReturnsAsync((User)null);
            var getUser = new GetUser(userRepositoryMock.Object);

            // Act
            var result = await getUser.Execute(userId);

            // Assert
            Assert.Null(result);
        }
    }
}