using CarMarket.Core;
using CarMarket.Repos.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Repos
{
    public class CarsRepository
    {
        private readonly CarMarketDbContext _ctx;
        public CarsRepository(CarMarketDbContext _ctx)
        {
            this._ctx = _ctx;
        }

        public async Task<Car> AddCarAsync(Car car)
        {
            _ctx.Cars.Add(car);
            await _ctx.SaveChangesAsync();
            return _ctx.Cars.Include(x => x.Brand).FirstOrDefault(x => x.Name == car.Name);
        }

        public Car GetCar(int id)
        {
            return _ctx.Cars.Include(x => x.Brand).Include(x => x.Name).FirstOrDefault(x => x.Id == id);
        }

        public List<Car> GetCars()
        {
            var carList = _ctx.Cars.Include(x => x.Brand).ToList();
            return carList;
        }


        public async Task DeleteCarAsync(int id)
        {
            _ctx.Remove(GetCar(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateCarAsync(Car updatedCar)
        {
            var car = _ctx.Cars.FirstOrDefault(x => x.Id == updatedCar.Id);
            car.Name = updatedCar.Name;
            car.Description = updatedCar.Description;
            car.Price = updatedCar.Price;
            car.Color = updatedCar.Color;
            car.Engine = updatedCar.Engine;
            car.Brand = updatedCar.Brand;
            car.Model = updatedCar.Model;

            await _ctx.SaveChangesAsync();
        }

        public async Task<CarCreateDto> GetCarDto(int id)
        {
            var k = await _ctx.Cars.Include(x => x.Brand).FirstAsync(x => x.Id == id);
            var car = await _ctx.Cars.Include(x => x.Model).FirstAsync(x => x.Id == id);

            var carDto = new CarCreateDto
            {
                Id = k.Id,
                Name = k.Name,
                Description = k.Description,
                Price = k.Price,
                Color = k.Color,
                Engine = k.Engine,
                Brand = k.Brand.Name,
                Model = k.Model.Name
            };
            return carDto;
        }

        public async Task UpdateAsync(CarCreateDto model, string brands, string models)
        {
            var car = _ctx.Cars.Include(x => x.Brand).FirstOrDefault(x => x.Id == model.Id);
            var k = _ctx.Cars.Include(x => x.Model).FirstOrDefault(x => x.Id == model.Id);

            if (car.Name != model.Name)
                car.Name = model.Name;
            if (car.Description != model.Description)
                car.Description = model.Description;
            if (car.Color != model.Color)
                car.Color = model.Color;
            if (car.Engine != model.Engine)
                car.Engine = model.Engine;
            if (car.Brand.Name != brands)
                car.Brand = _ctx.Brands.FirstOrDefault(x => x.Name == brands);
            if (car.Model.Name != models)
                car.Model = _ctx.Models.FirstOrDefault(x => x.Name == models);
            _ctx.SaveChanges();
        }
    }
}
