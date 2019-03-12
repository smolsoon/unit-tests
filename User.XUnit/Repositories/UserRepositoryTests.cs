using System.Threading.Tasks;
using Xunit;
using User.Api.Model;
using System;
using User.Api.Repositories;

namespace User.XUnit.Repositories
{
    public class UserRepositoryTests
    {
        [Fact]
        public async Task when_adding_new_user_it_should_be_added_correctly_to_the_list()
        {
            //Arrange
            var user = new Users(Guid.NewGuid(),"userFirstname","userLastname",23);
            IUserRepository repository = new UserRepository();

            //Act
            await repository.AddUserAsync(user);

            //Assert
            var existingUser = await repository.GetUserAsync(user.Id);
            Assert.Equal(user,existingUser);
        }
    }
}