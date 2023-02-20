using CarMarket.Repos;
using Microsoft.AspNetCore.Mvc;

namespace CarMarket.UI.Controllers
{
    public class ModelController : Controller
    {
        private readonly ModelRepository _modelRepository;
        private readonly BrandRepository _brandRepository;
        public ModelController(ModelRepository modelRepository, BrandRepository brandRepository)
        {
            _modelRepository = modelRepository;
            _brandRepository = brandRepository;
        }

        public IActionResult Index()
        {
            var models = _modelRepository.GetModels();
            return View(models);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Brands = _brandRepository.GetBrands();
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CarMarket.Core.Model model)
        {
            if (ModelState.IsValid)
            {
                var createdModel = await _modelRepository.AddModelAsync(model);
                return RedirectToAction("Edit", "Model", new { id = createdModel.Id });
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_modelRepository.GetModel(id));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(CarMarket.Core.Model model)
        {
            if (ModelState.IsValid)
            {
                await _modelRepository.UpdateModelAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_modelRepository.GetModel(id));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(CarMarket.Core.Model model)
        {
            await _modelRepository.DeleteModelAsync(model.Id);
            return RedirectToAction("Index");
        }

    }
}
