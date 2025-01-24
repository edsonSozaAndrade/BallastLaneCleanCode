using Core.Entities;
using Core.Implementations;
using Core.Interfaces;
using Moq;

namespace Tests.Core
{
    public class UpdateExistingUserTests
    {
        [Fact]
        public async Task Execute_ShouldUpdateUser()
        {
            // Arrange
            var updatedUser = new User { Id = Guid.NewGuid(), Username = "updateduser" };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.Update(updatedUser)).ReturnsAsync(updatedUser);
            var updateExistingUser = new UpdateExistingUser(userRepositoryMock.Object);

            // Act
            var result = await updateExistingUser.Execute(updatedUser);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedUser.Username, result.Username);
            userRepositoryMock.Verify(repo => repo.Update(updatedUser), Times.Once);
        }
    }
}
