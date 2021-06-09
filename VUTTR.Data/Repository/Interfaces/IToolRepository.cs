using System.Collections.Generic;
using System.Threading.Tasks;
using VUTTR.Domain.Models;

namespace VUTTR.Data.Repository.Interfaces
{
    public interface IToolRepository
    {
        Task<List<Tool>> GetAll();
        Task<Tool> GetById(int ToolId);
        Task<List<Tool>> GetByTag(string search);
        Task<Tool> Insert(Tool model);
        Task<Tool> Update(Tool model);
        Task<bool> Delete(int ToolId);
    }
}