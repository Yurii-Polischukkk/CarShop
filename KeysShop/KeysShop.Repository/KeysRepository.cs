using KeysShop.Core;
using KeysShop.Repository.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KeysShop.Repository
{
    public class KeysRepository
    {
        private readonly KeysShopContext _ctx;
        public KeysRepository(KeysShopContext _ctx)
        {
            this._ctx = _ctx;
        }

        public async Task<Key> AddKeyAsync(Key key)
        {
            _ctx.Keys.Add(key);
            await _ctx.SaveChangesAsync();
            return _ctx.Keys.Include(x => x.Brand).FirstOrDefault(x => x.Name == key.Name);
        }

        public Key GetKey(int id)
        {
            return _ctx.Keys.Include(x=>x.Brand).Include(x=>x.Name).FirstOrDefault(x => x.Id == id);
        }

        public List<Key> GetKeys()
        {
            var keyList = _ctx.Keys.Include(x => x.Brand).ToList();
            return keyList;
        }


        public async Task DeleteKeyAsync(int id)
        {
            _ctx.Remove(GetKey(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateKeyAsync(Key updatedKey)
        {
            var key = _ctx.Keys.FirstOrDefault(x => x.Id == updatedKey.Id);
            key.Name = updatedKey.Name;
            key.Description = updatedKey.Description;
            key.Price = updatedKey.Price;
            key.Color = updatedKey.Color;
            key.Engine = updatedKey.Engine;
            key.ImgPath = updatedKey.ImgPath;
            key.Brand = updatedKey.Brand;
            key.Model = updatedKey.Model;
            
            await _ctx.SaveChangesAsync();
        }

        public async Task<KeyCreateDto> GetKeyDto(int id)
        {
            var k = await _ctx.Keys.Include(x=>x.Brand).FirstAsync(x => x.Id == id);
            var key = await _ctx.Keys.Include(x=>x.Model).FirstAsync(x => x.Id == id);

            var keyDto = new KeyCreateDto
            {
                Id = k.Id,
                Name = k.Name,
                Description = k.Description,
                Price = k.Price,
                Color = k.Color,
                Engine = k.Engine,
                ImgPath = k.ImgPath,
                Brand = k.Brand.Name,
                Model= k.Model.Name
            };
            return keyDto;
        }

        public async Task UpdateAsync(KeyCreateDto model, string brands, string models)
        {
            var key = _ctx.Keys.Include(x=>x.Brand).FirstOrDefault(x=>x.Id==model.Id);
            var k = _ctx.Keys.Include(x=>x.Model).FirstOrDefault(x=>x.Id==model.Id);

            if (key.Name != model.Name)
                key.Name = model.Name;
            if (key.Description != model.Description)
                key.Description = model.Description;
            if (key.Color != model.Color)
                key.Color = model.Color;
            if (key.Engine != model.Engine)
                key.Engine = model.Engine;
            if (key.ImgPath != model.ImgPath)
                key.ImgPath = model.ImgPath;
            if (key.Brand.Name != brands)
                key.Brand = _ctx.Brands.FirstOrDefault(x=>x.Name==brands);
            if (key.Model.Name != models)
                key.Model = _ctx.Models.FirstOrDefault(x => x.Name == models);
            _ctx.SaveChanges();
        }
    }
}
