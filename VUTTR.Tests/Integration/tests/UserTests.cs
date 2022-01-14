using Xunit;
using System.Threading.Tasks;
using VUTTR.Tests.Integration.Fixtures;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Linq;
using System;
using VUTTR.Domain.ViewModels;

namespace VUTTR.Tests.Integration.Tests
{
    public class UserTests
    {
        private readonly TestContext _context;
        private readonly UserViewModel _userAdmin;
        public UserTests()
        {
            _context = new TestContext();
            _userAdmin = _context.GetUserAdmin;
        }

        // [Fact]
        public async Task User_Update_ReturnsOkResponse()
        {
            await _context.SetupClient();
            UserViewModel dto = _userAdmin;
            dto.UserId = 13;

            var json = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await _context._client.PutAsync("/api/User/", stringContent);

            Assert.True(response.StatusCode.Equals(HttpStatusCode.OK));
        }

        // [Fact]
        public async Task User_Register_ReturnsOkResponse()
        {
            await _context.SetupClient();
            Random random = new Random();
            const int length = 10;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string user = new string(Enumerable.Repeat(chars, length)
                            .Select(s => s[random.Next(s.Length)]).ToArray());

            var json = JsonConvert.SerializeObject(new UserViewModel { UserName = user, Password = "YWRtaW4=", RefreshTokenExpiryTime = DateTime.Now });
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await _context._client.PostAsync("/api/User/Register", stringContent);

            Assert.True(response.StatusCode.Equals(HttpStatusCode.OK));
        }

        // [Fact]
        public async Task User_Register_ReturnsBadRequestResponse()
        {
            await _context.SetupClient();
            var json = JsonConvert.SerializeObject(_userAdmin);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await _context._client.PostAsync("/api/User/Register", stringContent);
            Assert.True(response.StatusCode.Equals(HttpStatusCode.BadRequest));
        }

        // [Fact]
        public async Task User_GetById_ReturnsOkResponse()
        {
            await _context.SetupClient();
            var response = await _context._client.GetAsync("/api/User/5");
            Assert.True((response.StatusCode.Equals(HttpStatusCode.OK) || response.StatusCode.Equals(HttpStatusCode.NoContent)));
        }
    }
}
