using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Api.DTO;

namespace User.Api.Services {
    public interface IUserService {
        Task<UserDetailsDTO> GetUserAsync (Guid id);
        Task<IEnumerable<UserDTO>> GetAllUserAsync ();
        Task CreateAsync (Guid id, string firstname, string lastname, int age);
    }
}