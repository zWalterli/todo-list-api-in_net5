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
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public ToolService(IToolRepository repo, ITagRepository tagRepository, IMapper map)
        {
            _mapper = map;
            _tagRepository = tagRepository;
            _toolRepository = repo;
        }

        public async Task<ToolViewModel> GetById(int ToolId)
        {
            var tool = await _toolRepository.GetOne(x => x.Id == ToolId, x => x.Tags);
            return _mapper.Map<ToolViewModel>(tool);
        }

        public async Task<bool> Delete(int ToolId)
        {
            var tool = await _toolRepository.GetOne(x => x.Id == ToolId);
            await _toolRepository.Delete(tool);
            return true;
        }

        public async Task<List<ToolViewModel>> GetAll()
        {
            var tools = await _toolRepository.Get(x => x.Id > 0, x => x.Tags);
            return _mapper.Map<List<ToolViewModel>>(tools);
        }

        public async Task<List<ToolViewModel>> GetByTag(string search)
        {
            var listToolsFilter = new List<Tool>();
            var toolsListModel = await _toolRepository.Get(x => x.Tags.Any(y => y.Description.Contains(search)));

            // removendo itens iguais
            listToolsFilter = toolsListModel.Distinct().ToList();

            return _mapper.Map<List<ToolViewModel>>(listToolsFilter);
        }

        public async Task<ToolViewModel> Insert(ToolViewModel Obj)
        {
            var objModel = _mapper.Map<Tool>(Obj);
            return _mapper.Map<ToolViewModel>(await _toolRepository.Insert(objModel));
        }

        public async Task<ToolViewModel> Update(ToolViewModel Obj)
        {
            var model = _mapper.Map<Tool>(Obj);
            var tagsNaBase = (await _tagRepository.Get(x => x.ToolId == model.Id)).ToList();

            var tagsParaInserir = new List<Tag>();
            var tagsParaAtualizar = new List<Tag>();

            foreach (var tag in model.Tags)
            {
                var tagExistente = tagsNaBase
                    .Where(c => c.Id == tag.Id && c.Id != default(int))
                    .SingleOrDefault();

                if (tagExistente != null) // Update
                {
                    if (tagExistente.Description != tag.Description)
                        tagsParaAtualizar.Add(tag.Clone());
                }
                else // Insert
                {
                    tagsParaInserir.Add(tag.Clone());
                }
            }

            if (tagsParaInserir.Count > 0)
                await _tagRepository.Insert(tagsParaInserir);

            if (tagsParaAtualizar.Count > 0)
                await _tagRepository.Update(tagsParaAtualizar);

            model.Tags = null;
            return _mapper.Map<ToolViewModel>(await _toolRepository.Update(model));
        }
    }
}