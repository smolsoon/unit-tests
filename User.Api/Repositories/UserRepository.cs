using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using User.Api.Database;
using User.Api.Model;

namespace User.Api.Repositories {
    public class UserRepository : IUserRepository {
        private readonly DatabaseContext _database;
        private readonly ILoggerFactory _logger;
        public UserRepository () {

        }
        public UserRepository (DatabaseContext database, ILoggerFactory logger) {
            _database = database;
            _logger = logger;
        }
        public async Task<Users> GetUserAsync (Guid id) => await _database.Users.SingleOrDefaultAsync (x => x.Id == id);
        public async Task<IEnumerable<Users>> GetAllUserAsync () => await _database.Users.OrderBy (x => x.Firstname).ToListAsync ();

        public async Task<Users> AddUserAsync (Users user) {
            _database.Add (user);

            try {
                await _database.SaveChangesAsync ();
            } catch (System.Exception exp) {
                _logger.CreateLogger ($"Error is {nameof(AddUserAsync)}: " + exp.Message);
            }
            return user;
        }
    }
}