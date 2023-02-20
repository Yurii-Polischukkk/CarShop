using CarMarket.Core;
using CarMarket.Repos;
using CarMarket.Repos.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Model = CarMarket.Core.Model;

namespace CarMarket.UI.Controllers
{
    public class CarController : Controller
    {
        private readonly CarsRepository carsRepository;
        private readonly BrandRepository brandsRepository;
        private readonly ModelRepository modelsRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CarController(CarsRepository carsRepository, BrandRepository brandRepository, ModelRepository modelRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.carsRepository = carsRepository;
            brandsRepository = brandRepository;
            modelsRepository = modelRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cars = carsRepository.GetCars();
            return View(cars);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Brands = brandsRepository.GetBrands();
            ViewBag.Models = modelsRepository.GetModels();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CarCreateDto carCreateDto, string brands, string models, IFormFile picture)
        {
            ViewBag.Brands = brandsRepository.GetBrands();
            ViewBag.Models = modelsRepository.GetModels();
            if (ModelState.IsValid)
            {
                string picturePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "cars", picture.FileName);

                using (FileStream stream = new FileStream(picturePath, FileMode.Create))
                    picture.CopyTo(stream);

                carCreateDto.ImgPath = Path.Combine("img", "cars", picture.FileName);



                var brand = brandsRepository.GetBrandByName(brands);
                if (brand == null)
                {
                    brand = new Brand() { Name = brands };
                    brand = await brandsRepository.AddBrandAsync(brand);
                }
                var model = modelsRepository.GetModelByName(models);
                if (model == null)
                {
                    model = new Model() { Name = models };
                    model = await modelsRepository.AddModelAsync(model);
                }
                var car = await carsRepository.AddCarAsync(new Car()
                {
                    Name = carCreateDto.Name,
                    Description = carCreateDto.Description,
                    Price = carCreateDto.Price,
                    Color = carCreateDto.Color,
                    Engine = carCreateDto.Engine,
                    ImgPath = carCreateDto.ImgPath,
                    Brand = brand,
                    Model = model
                });

                return RedirectToAction("Edit", "Car", new { id = car.Id });
            }
            return View(carCreateDto);
        }

        [HttpGet]
        public FileContentResult GetImgPath(int id)
        {
            var path = carsRepository.GetCar(id).ImgPath;
            var byteArray = System.IO.File.ReadAllBytes(path);
            return new FileContentResult(byteArray, "image/jpeg");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Brands = brandsRepository.GetBrands();
            ViewBag.Models = modelsRepository.GetModels();
            return View(await carsRepository.GetCarDto(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(CarCreateDto model, string brands, string models, IFormFile picture)
        {
            if (ModelState.IsValid)
            {
                string picturePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "cars", picture.FileName);

                using (FileStream stream = new FileStream(picturePath, FileMode.Create))
                    picture.CopyTo(stream);

                model.ImgPath = Path.Combine("img", "cars", picture.FileName);
                await carsRepository.UpdateAsync(model, brands, models);
                return RedirectToAction("Index");
            }
            ViewBag.Brands = brandsRepository.GetBrands();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View(await carsRepository.GetCarDto(id));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await carsRepository.GetCarDto(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await carsRepository.DeleteCarAsync(id);
            return RedirectToAction("Index");
        }
    }
}
