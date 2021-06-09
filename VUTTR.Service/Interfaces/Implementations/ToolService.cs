using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VUTTR.Data.Repository.Interfaces;
using VUTTR.Domain.DTOs;
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

        public async Task<List<ToolDto>> GetAll()
        {
            List<Tool> toolsModel = await _toolRepository.GetAll();
            return ConverterListModelToDto(toolsModel);
        }

        public async Task<ToolDto> GetById(int ToolId)
        {
            Tool toolsModel = await _toolRepository.GetById(ToolId);
            return ConverterModelToDto(toolsModel);
        }

        public async Task<List<ToolDto>> GetByTag(string search)
        {
            List<Tool> listToolsFilter = new List<Tool>();
            List<Tool> toolsListModel = await _toolRepository.GetByTag(search);

            // removendo itens iguais
            listToolsFilter = toolsListModel.Distinct().ToList();
            
            return ConverterListModelToDto(listToolsFilter);
        }

        public async Task<ToolDto> Insert(ToolDto Obj)
        {
            Tool objModel = new Tool(Obj);
            return ConverterModelToDto(await _toolRepository.Insert(objModel));
        }

        public async Task<ToolDto> Update(ToolDto Obj)
        {
            Tool objModel = new Tool(Obj);
            return ConverterModelToDto(await _toolRepository.Update(objModel));
        }

        private List<ToolDto> ConverterListModelToDto(List<Tool> listTools)
        {
            List<ToolDto> toolsDto = new List<ToolDto>();
            foreach (var tool in listTools)
            {
                ToolDto dto = new ToolDto(tool);
                toolsDto.Add(dto);
            }
            return toolsDto;
        }
        private ToolDto ConverterModelToDto(Tool tool)
        {
            return new ToolDto(tool);
        }
    }
}