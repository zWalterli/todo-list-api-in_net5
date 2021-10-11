using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using VUTTR.Data.Repository.Interfaces;
using VUTTR.Domain.Models;
using VUTTR.Domain.ViewModels;
using VUTTR.Service.Interfaces.Implementations;
using VUTTR.Service.Interfaces.Interfaces;
using VUTTR.Tests.Unitary.Mocks;
using Xunit;

namespace VUTTR.Tests.Unitary.tests
{
    public class ToolsServiceTest
    {
        private readonly ToolMock _toolMock;
        private readonly Mock<IToolRepository> _toolRep;
        private readonly IToolService _toolService;
        public ToolsServiceTest()
        {
            _toolMock = new ToolMock();
            _toolRep = new Mock<IToolRepository>();
            Setup();
            _toolService = new ToolService(_toolRep.Object);
        }

        private void Setup()
        {
            _toolRep.Setup(x => x.GetAll())
                .Returns(Task.FromResult( _toolMock.GetListToolsMock() ));

            _toolRep.Setup(x => x.GetById( It.IsAny<int>() ))
                .Returns(Task.FromResult( _toolMock.GetToolMock(1) ));

            _toolRep.Setup(x => x.Delete( It.IsAny<int>() ))
                .Returns(Task.FromResult(true));

            _toolRep.Setup(x => x.GetByTag( It.IsAny<string>() ))
                .Returns(Task.FromResult( _toolMock.GetListToolsMock() ));

            _toolRep.Setup(x => x.Insert( It.IsAny<Tool>() ))
                .Returns(Task.FromResult( _toolMock.GetToolMock(2) ));

            _toolRep.Setup(x => x.Update( It.IsAny<Tool>() ))
                .Returns(Task.FromResult( _toolMock.GetToolMock(2) ));
        }

        [Fact]
        public async Task GetAll_ReturnWithListTools()
        {
            List<ToolViewModel> Tools = await _toolService.GetAll();
            Assert.NotEmpty(Tools);
        }

        [Fact]
        public async Task GetById_ReturnWithOneTool()
        {
            ToolViewModel Tool = await _toolService.GetById(1);
            Assert.NotNull(Tool);
        }

        [Fact]
        public async Task GetByTag_ReturnWithListToolsByTag()
        {
            List<ToolViewModel> Tools = await _toolService.GetByTag("teste");
            Assert.NotEmpty(Tools);
        }

        [Fact]
        public async Task Insert_ReturnWithOneToolInserting()
        {
            ToolViewModel Tool = await _toolService.Insert(new ToolViewModel( _toolMock.GetToolMock(1) ));
            Assert.NotNull(Tool);
        }

        [Fact]
        public async Task Update_ReturnWithOneToolUpdating()
        {
            ToolViewModel Tool = await _toolService.Update(new ToolViewModel( _toolMock.GetToolMock(1) ));
            Assert.NotNull(Tool);
        }
    }
}