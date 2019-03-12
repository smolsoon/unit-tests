using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Api.Model;


namespace User.Api.Repositories {
    public interface IUserRepository {

        Task<Users> GetUserAsync (Guid id);
        Task<IEnumerable<Users>> GetAllUserAsync ();
        Task<Users> AddUserAsync (Users user);
    }
}