using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using User.Api;
using User.Api.DTO;
using Xunit;

namespace User.End2End.Controllers
{
    public class UserControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UserControllerTests()
        {
            //Arrange
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task fetching_user_events_should_return_not_empty_collection()
        {
            var response = await _client.GetAsync("users");
            var content = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<UserDetailsDTO>>(content);

            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);
            users.Should().NotBeEmpty();
        }
    }
}