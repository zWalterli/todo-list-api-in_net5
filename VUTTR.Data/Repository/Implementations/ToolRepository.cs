using VUTTR.Data.Repository.Interfaces;
using VUTTR.Domain.Models;
using VUTTR.Data.Context;

namespace VUTTR.Data.Repository.Implementations
{
    public class ToolRepository : Repository<Tool>, IToolRepository
    {
        private readonly VUTTRContext _ctx;

        public ToolRepository(VUTTRContext context) : base(context) =>
            _ctx = context;

    }
}