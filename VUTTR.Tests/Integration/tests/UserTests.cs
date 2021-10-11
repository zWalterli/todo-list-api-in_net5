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
        public UserTests()
        {
            _context = new TestContext();
        }

        [Fact]
        public async Task User_Update_ReturnsOkResponse()
        {
            UserViewModel dto = new UserViewModel
            {
                UserId = 8,
                UserName = "waljuni",
                Password = "dGVzdGU=",
            };
            
            var json = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await _context._client.PutAsync("/api/User/", stringContent);

            Assert.True( response.StatusCode.Equals(HttpStatusCode.OK) );
        }

        [Fact]
        public async Task User_Register_ReturnsOkResponse()
        {
            Random random = new Random();
            const int length = 10;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string user = new string(Enumerable.Repeat(chars, length)
                            .Select(s => s[random.Next(s.Length)]).ToArray());

            UserViewModel dto = new UserViewModel
            {
                UserName = user,
                Password = "dGVzdGU=",
            };
            
            var json = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await _context._client.PostAsync("/api/User/Register", stringContent);

            Assert.True( response.StatusCode.Equals(HttpStatusCode.OK) );
        }

        [Fact]
        public async Task User_Register_ReturnsBadRequestResponse()
        {
            var json = JsonConvert.SerializeObject( new UserViewModel { UserName = "admin", Password = "dGVzdGU=" } );
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await _context._client.PostAsync("/api/User/Register", stringContent);
            Assert.True( response.StatusCode.Equals(HttpStatusCode.BadRequest) );
        }

        [Fact]
        public async Task User_Login_ReturnsOkResponse()
        {
            UserViewModel dto = new UserViewModel
            {
                UserName = "admin",
                Password = "YWRtaW4="
            };
            
            var json = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await _context._client.PostAsync("/api/User/Login", stringContent);

            Assert.True( response.StatusCode.Equals(HttpStatusCode.OK) );
        }

        [Fact]
        public async Task User_GetById_ReturnsOkResponse()
        {
            var response = await _context._client.GetAsync("/api/User/1");
            Assert.True( response.StatusCode.Equals(HttpStatusCode.OK) );
        }
    }
}
