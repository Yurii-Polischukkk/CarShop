using CarMarket.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Repos
{
    public class ModelRepository
    {
        private readonly CarMarketDbContext _ctx;

        public ModelRepository(CarMarketDbContext _ctx)
        {
            this._ctx = _ctx;
        }

        public async Task<Model> AddModelAsync(Model model)
        {
            _ctx.Models.Add(model);
            await _ctx.SaveChangesAsync();
            return _ctx.Models.FirstOrDefault(x => x.Name == model.Name);
        }

        public Model GetModel(int id)
        {
            return _ctx.Models.FirstOrDefault(x => x.Id == id);
        }
        public Model GetModelByName(string name)
        {
            return _ctx.Models.FirstOrDefault(x => x.Name == name);
        }

        public List<Model> GetModels()
        {
            var modelList = _ctx.Models.ToList();
            return modelList;
        }

        public async Task DeleteModelAsync(int id)
        {
            _ctx.Remove(GetModel(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateModelAsync(Model updatedModel)
        {
            var model = _ctx.Models.FirstOrDefault(x => x.Id == updatedModel.Id);
            model.Description = updatedModel.Description;
            model.Name = updatedModel.Name;
            await _ctx.SaveChangesAsync();
        }
    }
}
