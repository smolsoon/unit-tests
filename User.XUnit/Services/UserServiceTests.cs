using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using User.Api.DTO;
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
            await userService.CreateAsync (Guid.NewGuid (), "userFirstname", "userLastname", 23);

            //Assert
            userRepositoryMock.Verify (x => x.AddUserAsync (It.IsAny<Users> ()), Times.Once ());
        }

        [Fact]
        public async Task when_invoking_get_async_it_should_invoke_get_async_on_user_repository () {
            //Arrange
            var user = new Users (Guid.NewGuid (), "userFirstname", "userLastname", 23);
            var userDetailsDto = new UserDetailsDTO {
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Age = user.Age
            };

            var userRepositoryMock = new Mock<IUserRepository> ();
            var mapperMock = new Mock<IMapper> ();
            mapperMock.Setup (x => x.Map<UserDetailsDTO> (user)).Returns (userDetailsDto);
            var userService = new UserService (userRepositoryMock.Object, mapperMock.Object);
            userRepositoryMock.Setup (x => x.GetUserAsync (user.Id)).ReturnsAsync (user);

            //Act
            var existingUserDetailsDto = await userService.GetUserAsync (user.Id);

            //Assert
            userRepositoryMock.Verify (x => x.GetUserAsync (user.Id), Times.Once ());
            userDetailsDto.Should ().NotBeNull ();
            userDetailsDto.Should().NotBeOfType(typeof(string));
            userDetailsDto.Firstname.ShouldBeEquivalentTo (user.Firstname);
            userDetailsDto.Age.ShouldBeEquivalentTo(user.Age);
            userDetailsDto.Lastname.ShouldBeEquivalentTo(user.Lastname);
        }
    }
}