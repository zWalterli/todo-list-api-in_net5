using System.Collections.Generic;
using VUTTR.Data.Repository.Interfaces;
using VUTTR.Domain.Models;
using VUTTR.Data.Context;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace VUTTR.Data.Repository.Implementations
{
    public class ToolRepository : IToolRepository
    {
        private readonly VUTTRContext _ctx;

        public ToolRepository(VUTTRContext context)
        {
            _ctx = context;
        }

        public async Task<bool> Delete(int ToolId)
        {
            try
            {
                Tool model = await this.GetById(ToolId);
                if (model == null) return true;

                _ctx.Remove(model);
                return (await _ctx.SaveChangesAsync() > 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Tool>> GetAll()
        {
            try
            {
                return await _ctx.Tools.Include(x => x.Tags).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Tool> GetById(int ToolId)
        {
            try
            {
                return await _ctx.Tools.Include(x => x.Tags).FirstOrDefaultAsync(x => x.id.Equals(ToolId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Tool>> GetByTag(string search)
        {
            try
            {
                List<Tool> ToolsModel = await this.GetAll();
                List<Tool> listTools = new List<Tool>();

                ToolsModel.ForEach(
                    tool => tool.Tags.ForEach(tag =>
                    {
                        if (tag.description.ToLower().Contains(search.ToLower()))
                        {
                            listTools.Add(tool);
                        }
                    })
                );

                return listTools;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Tool> Insert(Tool model)
        {
            try
            {
                await _ctx.AddAsync(model);
                await _ctx.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Tool> Update(Tool model)
        {
            _ctx.Tools.Update(model);
            await _ctx.SaveChangesAsync();
            return model;
        }
    }
}