using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using User.Api.DTO;
using User.Api.Repositories;
using User.Api.Model;


namespace User.Api.Services {
    public class UserService : IUserService {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserService (IUserRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDetailsDTO> GetUserAsync (Guid id) {
            var user = await _repository.GetUserAsync (id);
            return _mapper.Map<UserDetailsDTO> (user);
        }
        public async Task<IEnumerable<UserDTO>> GetAllUserAsync () {
            var User = await _repository.GetAllUserAsync ();
            return _mapper.Map<IEnumerable<UserDTO>> (User);
        }
        public async Task CreateAsync (Guid id, string firstname, string lastname, int age) {
            var user = await _repository.GetUserAsync (id);
            if (user != null) {
                throw new Exception ($" User {user} already exists");
            }
            user = new Users (id, firstname, lastname, age);
            await _repository.AddUserAsync (user);
        }
    }
}