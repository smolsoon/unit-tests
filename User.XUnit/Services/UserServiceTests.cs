using System;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using User.Api.Model;
using User.Api.Repositories;
using User.Api.Services;
using Xunit;

namespace User.XUnit.Services {
    public class UserServiceTests {
        [Fact]
        public async Task register_async_should_invoke_add_async_on_user_repository () {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository> ();
            var mapperMock = new Mock<IMapper> ();
            var userService = new UserService (userRepositoryMock.Object, mapperMock.Object);

            //Act
            await userService.CreateAsync (Guid.NewGuid(),"userFirstname","userLastname",23);

            //Assert
            userRepositoryMock.Verify (x => x.AddUserAsync (It.IsAny<Users> ()), Times.Once ());
        }
    }
}