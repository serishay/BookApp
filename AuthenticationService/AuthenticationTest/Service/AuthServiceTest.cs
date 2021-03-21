using AuthenticationService.BusinessLayer;
using AuthenticationService.CustomException;
using AuthenticationService.Models;
using AuthenticationService.Repository;
using Moq;
using Test;
using Xunit;

namespace Service.Test
{
    [TestCaseOrderer("Test.PriorityOrderer", "Test")]
    public class AuthServiceTest
    {
        [Fact, TestPriority(4)]
        public void RegisterUserShouldSuccess()
        {
            var mockRepo = new Mock<IAuthRepository>();
            User user = new User { UserId = "XYZ", Password = "123" };
            mockRepo.Setup(repo => repo.IsUserExists(user.UserId)).Returns(false);
            mockRepo.Setup(repo => repo.CreateUser(user)).Returns(true);
            var service = new AuthService(mockRepo.Object);

            var actual = service.RegisterUser(user);
            Assert.True(actual);
        }

        [Fact, TestPriority(5)]
        public void LoginUserShouldSuccess()
        {
            var mockRepo = new Mock<IAuthRepository>();
            User user = new User { UserId = "XYZ", Password = "123" };
            mockRepo.Setup(repo => repo.LoginUser(user)).Returns(true);
            var service = new AuthService(mockRepo.Object);

            var actual = service.LoginUser(user);
            Assert.True(actual);
        }

        [Fact, TestPriority(6)]
        public void RegisterUserShouldFail()
        {
            var mockRepo = new Mock<IAuthRepository>();
            User user = new User { UserId = "XYZ", Password = "123" };
            mockRepo.Setup(repo => repo.IsUserExists(user.UserId)).Returns(true);
            var service = new AuthService(mockRepo.Object);

            var actual = Assert.Throws<UserAlreadyExistsException>(() => service.RegisterUser(user));
            Assert.Equal($"This userId {user.UserId} already in use", actual.Message);
        }
    }
}