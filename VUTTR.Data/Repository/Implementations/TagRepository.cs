using VUTTR.Data.Context;
using VUTTR.Data.Repository.Interfaces;
using VUTTR.Domain.Models;

namespace VUTTR.Data.Repository.Implementations
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        private readonly VUTTRContext _ctx;

        public TagRepository(VUTTRContext context) : base(context) =>
            _ctx = context;
    }
}