using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VUTTR.Domain.ViewModels;
using VUTTR.Tests.Integration.Fixtures;
using Xunit;

namespace VUTTR.Tests.Integration.Tests
{
    public class ToolsTests
    {
        private readonly TestContext _context;
        public ToolsTests()
        {
            _context = new TestContext();
        }

        [Fact]
        public async Task Tool_GetByTag_ReturnsOkResponse()
        {
            var response = await _context._client.GetAsync("/api/Tools?tag=git");
            Assert.True( response.StatusCode.Equals(HttpStatusCode.OK) );
        }

        [Fact]
        public async Task Tool_Post_ReturnsCreatedResponse()
        {
            ToolViewModel dto = new ToolViewModel
            {
                title = "teste",
                link = "www.teste.com.br",
                description = "teste",
                Tags = new List<string> { "teste1", "teste2", "teste3" }
            };
            
            var json = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await _context._client.PostAsync("/api/Tools/", stringContent);
            Assert.True( response.StatusCode.Equals(HttpStatusCode.Created) );
        }

        [Fact]
        public async Task Tool_Put_ReturnsOkResponse()
        {
            ToolViewModel dto = new ToolViewModel
            {
                id = 1,
                title = "GitHub",
                link = "www.github.com.br",
                description = "Ferramenta para realizar o versionamento de códigos fontes.",
                Tags = new List<string> {"gitlab", "dev", "versionamento"}
            };
            
            var json = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await _context._client.PutAsync("/api/Tools/", stringContent);
            Assert.True( response.StatusCode.Equals(HttpStatusCode.OK) );
        }

        [Fact]
        public async Task Tool_Delete_ReturnsNoContentResponse()
        {
            var response = await _context._client.DeleteAsync("/api/Tools/3");
            var scResponse = (int)response.StatusCode;
            var scHttp = (int)HttpStatusCode.NoContent;
            Assert.True( scResponse == scHttp );
        }
    }
}