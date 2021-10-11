using System.Collections.Generic;
using System.Threading.Tasks;
using VUTTR.Domain.ViewModels;

namespace VUTTR.Service.Interfaces.Interfaces
{
    public interface IToolService
    {
        Task<List<ToolViewModel>> GetAll();
        Task<ToolViewModel> GetById(int ToolId);
        Task<List<ToolViewModel>> GetByTag(string search);
        Task<ToolViewModel> Insert(ToolViewModel Obj);
        Task<ToolViewModel> Update(ToolViewModel Obj);
        Task<bool> Delete(int ToolId);
    }
}