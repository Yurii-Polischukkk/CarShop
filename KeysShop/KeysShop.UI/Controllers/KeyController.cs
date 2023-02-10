using KeysShop.Core;
using KeysShop.Repository;
using KeysShop.Repository.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.IO;
namespace KeysShop.UI.Controllers
{
    public class KeyController : Controller
    {
        private readonly KeysRepository keysRepository;
        private readonly BrandRepository brandsRepository;
        private readonly ModelRepository modelsRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public KeyController(KeysRepository keysRepository, BrandRepository brandRepository, ModelRepository modelRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.keysRepository = keysRepository;
            brandsRepository = brandRepository;
            modelsRepository = modelRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var keys = keysRepository.GetKeys();
            return View(keys);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Brands = brandsRepository.GetBrands();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(KeyCreateDto keyCreateDto, string brands, string models, IFormFile picture)
        {
            ViewBag.Brands = brandsRepository.GetBrands();
            ViewBag.Models = modelsRepository.GetModels();
            if (ModelState.IsValid)
            {
                string picturePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "keys", picture.FileName);

                using (FileStream stream = new FileStream(picturePath, FileMode.Create))
                    picture.CopyTo(stream);

                keyCreateDto.ImgPath = Path.Combine("img", "keys", picture.FileName);

                

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
                var key = await keysRepository.AddKeyAsync(new Key()
                {
                    Name = keyCreateDto.Name,
                    Description = keyCreateDto.Description,
                    Price = keyCreateDto.Price,
                    Color = keyCreateDto.Color,
                    Engine = keyCreateDto.Engine,
                    ImgPath = keyCreateDto.ImgPath,
                    Brand = brand,
                    Model = model
                });

                return RedirectToAction("Edit", "Key", new { id = key.Id });
            }
            return View(keyCreateDto);
        }

        [HttpGet]
        public FileContentResult GetImgPath(int id)
        {
            var path = keysRepository.GetKey(id).ImgPath;
            var byteArray = System.IO.File.ReadAllBytes(path);
            return new FileContentResult(byteArray, "image/jpeg");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Brands = brandsRepository.GetBrands();
            ViewBag.Models = modelsRepository.GetModels();
            return View( await keysRepository.GetKeyDto(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(KeyCreateDto model, string brands, string models, IFormFile picture)
        {
            if (ModelState.IsValid)
            {
                string picturePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "keys", picture.FileName);

                using (FileStream stream = new FileStream(picturePath, FileMode.Create))
                    picture.CopyTo(stream);

                model.ImgPath = Path.Combine("img", "keys", picture.FileName);
                await keysRepository.UpdateAsync(model, brands, models);
                return RedirectToAction("Index");
            }
            ViewBag.Brands = brandsRepository.GetBrands();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View(await keysRepository.GetKeyDto(id));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await keysRepository.GetKeyDto(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await keysRepository.DeleteKeyAsync(id);
            return RedirectToAction("Index");
        }
    }
}
