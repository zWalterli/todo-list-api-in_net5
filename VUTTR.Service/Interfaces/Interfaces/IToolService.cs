using System.Collections.Generic;
using System.Threading.Tasks;
using VUTTR.Domain.DTOs;

namespace VUTTR.Service.Interfaces.Interfaces
{
    public interface IToolService
    {
        Task<List<ToolDto>> GetAll();
        Task<ToolDto> GetById(int ToolId);
        Task<List<ToolDto>> GetByTag(string search);
        Task<ToolDto> Insert(ToolDto Obj);
        Task<ToolDto> Update(ToolDto Obj);
        Task<bool> Delete(int ToolId);
    }
}