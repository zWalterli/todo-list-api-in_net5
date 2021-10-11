using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VUTTR.Data.Repository.Interfaces;
using VUTTR.Domain.ViewModels;
using VUTTR.Domain.Models;
using VUTTR.Service.Interfaces.Interfaces;

namespace VUTTR.Service.Interfaces.Implementations
{
    public class ToolService : IToolService
    {
        private readonly IToolRepository _toolRepository;

        public ToolService(IToolRepository repo)
        {
            _toolRepository = repo;
        }

        public Task<bool> Delete(int ToolId)
        {
            return _toolRepository.Delete(ToolId);
        }

        public async Task<List<ToolViewModel>> GetAll()
        {
            List<Tool> toolsModel = await _toolRepository.GetAll();
            return ConverterListModelToDto(toolsModel);
        }

        public async Task<ToolViewModel> GetById(int ToolId)
        {
            Tool toolsModel = await _toolRepository.GetById(ToolId);
            return ConverterModelToDto(toolsModel);
        }

        public async Task<List<ToolViewModel>> GetByTag(string search)
        {
            List<Tool> listToolsFilter = new List<Tool>();
            List<Tool> toolsListModel = await _toolRepository.GetByTag(search);

            // removendo itens iguais
            listToolsFilter = toolsListModel.Distinct().ToList();
            
            return ConverterListModelToDto(listToolsFilter);
        }

        public async Task<ToolViewModel> Insert(ToolViewModel Obj)
        {
            Tool objModel = new Tool(Obj);
            return ConverterModelToDto(await _toolRepository.Insert(objModel));
        }

        public async Task<ToolViewModel> Update(ToolViewModel Obj)
        {
            Tool objModel = new Tool(Obj);
            return ConverterModelToDto(await _toolRepository.Update(objModel));
        }

        private List<ToolViewModel> ConverterListModelToDto(List<Tool> listTools)
        {
            List<ToolViewModel> toolsDto = new List<ToolViewModel>();
            if(listTools == null)
                return toolsDto;

            foreach (var tool in listTools)
            {
                ToolViewModel dto = new ToolViewModel(tool);
                toolsDto.Add(dto);
            }
            return toolsDto;
        }
        private ToolViewModel ConverterModelToDto(Tool tool)
        {
            if(tool == null)
                return new ToolViewModel();

            return new ToolViewModel(tool);
        }
    }
}