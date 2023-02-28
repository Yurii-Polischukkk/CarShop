using CarMarket.Repos;
using CarMarket.Core;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace CarMarket.UI.Controllers
{
    public class SearchController : Controller
    {
        private readonly CarsRepository carsRepository;

        public SearchController(CarsRepository carsRepository)
        {
            this.carsRepository = carsRepository;
        }

        public async Task<IActionResult> SearchCar(string carname)
        {
            if (String.IsNullOrEmpty(carname))
            {
                return RedirectToAction("SearchError");
            }
            var list = carsRepository.GetCars();
            /* list = list.Where(s => s.Name!.ToLower().Contains(keyname.ToLower())).ToList();*/
            list = list.
                Where(x => x.Name.ToLower().Contains(carname.ToLower())
                || x.Description.ToLower().Contains(carname.ToLower())                
                || x.Brand.Name.ToLower().Contains(carname.ToLower())).ToList();

            ViewBag.Cars = list;

            return View("Index");
        }

        public IActionResult SearchError()
        {
            ViewBag.Message = "Пошукова стрічка не може бути пустою";
            return View();
        }
    }
}
