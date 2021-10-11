using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VUTTR.Data.Repository.Interfaces;
using VUTTR.Domain.ViewModels;
using VUTTR.Domain.Models;
using VUTTR.Service.Interfaces.Interfaces;
using AutoMapper;

namespace VUTTR.Service.Interfaces.Implementations
{
    public class ToolService : IToolService
    {
        private readonly IToolRepository _toolRepository;
        private readonly IMapper _mapper;

        public ToolService(IToolRepository repo, IMapper map)
        {
            _mapper = map;
            _toolRepository = repo;
        }

        public Task<bool> Delete(int ToolId)
        {
            return _toolRepository.Delete(ToolId);
        }

        public async Task<List<ToolViewModel>> GetAll()
        {
            List<Tool> toolsModel = await _toolRepository.GetAll();
            return _mapper.Map<List<ToolViewModel>>(toolsModel);
        }

        public async Task<ToolViewModel> GetById(int ToolId)
        {
            Tool toolsModel = await _toolRepository.GetById(ToolId);
            return _mapper.Map<ToolViewModel>(toolsModel);
        }

        public async Task<List<ToolViewModel>> GetByTag(string search)
        {
            List<Tool> listToolsFilter = new List<Tool>();
            List<Tool> toolsListModel = await _toolRepository.GetByTag(search);

            // removendo itens iguais
            listToolsFilter = toolsListModel.Distinct().ToList();
            
            return _mapper.Map<List<ToolViewModel>>(listToolsFilter);
        }

        public async Task<ToolViewModel> Insert(ToolViewModel Obj)
        {
            Tool objModel = _mapper.Map<Tool>(Obj);
            return _mapper.Map<ToolViewModel>(await _toolRepository.Insert(objModel));
        }

        public async Task<ToolViewModel> Update(ToolViewModel Obj)
        {
            Tool objModel = _mapper.Map<Tool>(Obj);
            foreach (var tag in objModel.Tags)
                tag.Tool = objModel;

            return _mapper.Map<ToolViewModel>(await _toolRepository.Update(objModel));
        }
    }
}