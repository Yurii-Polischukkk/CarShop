using KeysShop.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using KeysShop.Core;
using KeysShop.Repository;
using System.Diagnostics;

namespace KeysShop.UI.Controllers
{
    public class SearchController : Controller
    {
        private readonly KeysRepository keysRepository;

        public SearchController(KeysRepository keysRepository)
        {
            this.keysRepository = keysRepository;
        }

        public async Task<IActionResult> SearchKey(string keyname)
        {
            if(String.IsNullOrEmpty(keyname))
            {
                return RedirectToAction("SearchError");
            }
            var list = keysRepository.GetKeys();
           /* list = list.Where(s => s.Name!.ToLower().Contains(keyname.ToLower())).ToList();*/
            list = list.
                Where(x => x.Name.ToLower().Contains(keyname.ToLower())
                || x.Description.ToLower().Contains(keyname.ToLower())
                || x.Brand.Name.ToLower().Contains(keyname.ToLower())).ToList();

            ViewBag.Keys = list;

            return View("Index");
        }

        public IActionResult SearchError()
        {
            ViewBag.Message = "Пошукова стрічка не може бути пустою";
            return View();
        }
    }
}
