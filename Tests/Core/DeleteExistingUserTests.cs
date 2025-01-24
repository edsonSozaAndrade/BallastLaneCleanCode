using Core.Entities;
using Core.Implementations;
using Core.Interfaces;
using Moq;

namespace Tests.Core
{
    public class DeleteExistingUserTests
    {
        [Fact]
        public async Task Execute_ShouldDeleteUser()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new User { Id = userId };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.Delete(userId)).ReturnsAsync(user);
            var deleteExistingUser = new DeleteExistingUser(userRepositoryMock.Object);

            // Act
            var result = await deleteExistingUser.Execute(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
            userRepositoryMock.Verify(repo => repo.Delete(userId), Times.Once);
        }
    }
}