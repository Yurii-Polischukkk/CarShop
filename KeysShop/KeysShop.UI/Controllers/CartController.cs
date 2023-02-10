using KeysShop.Core;
using KeysShop.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KeysShop.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly KeysRepository keysRepository;

        public CartController(KeysRepository keysRepository)
        {
            this.keysRepository = keysRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public void Buy(int id)
        {
            if (HttpContext.Session.GetObject<List<CartItem>>("cart") == null)
            {
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem { Id = cart.Count, Key = keysRepository.GetKey(id), Quantity = 1 });
                HttpContext.Session.SetObject("cart", cart);
            }
            else
            {
                var cart = HttpContext.Session.GetObject<List<CartItem>>("cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartItem { Id = cart.Count, Key = keysRepository.GetKey(id), Quantity = 1 });
                }
                HttpContext.Session.SetObject("cart", cart);
                
            }
            var cart1 = HttpContext.Session.GetObject<List<CartItem>>("cart");

        }
        [HttpPost]
        public double? IncreaseKey(int id)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("cart");
            cart[id].Quantity += 1;
            double? sum = 0;
            foreach (var item in cart)
                sum+=item.Quantity*item.Key.Price;
            HttpContext.Session.SetObject("cart", cart);

            var cart1 = HttpContext.Session.GetObject<List<CartItem>>("cart");
            return sum;

        }
        [HttpPost]
        public double? DecreaseKey(int id)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("cart");
            cart[id].Quantity -= 1;
            double? sum = 0;
            foreach (var item in cart)
                sum+=item.Quantity*item.Key.Price;
            HttpContext.Session.SetObject("cart", cart);


            return sum;
        }/*
        public ActionResult Buy(int id)
        {
            if (HttpContext.Session.GetObject<List<CartItem>>("cart") == null)
            {
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem { Key = keysRepository.GetKey(id), Quantity = 1 });
                HttpContext.Session.SetObject("cart", cart);
            }
            else
            {
                var cart = HttpContext.Session.GetObject<List<CartItem>>("cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartItem { Key = keysRepository.GetKey(id), Quantity = 1 });
                }
                HttpContext.Session.SetObject("cart", cart);
            }
            return RedirectToAction("Index");
        }*/
        public int ReturnCartQuantity()
        {
            int quantity = 0;
            if (HttpContext.Session.GetObject<List<CartItem>>("cart") == null)
            {
                return 0;
            }
            else
            {
                var cart = HttpContext.Session.GetObject<List<CartItem>>("cart");
                foreach( var item in cart)
                {
                    quantity+=item.Quantity;
                }
            }
            return quantity;
        }

        public ActionResult Remove(int id)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("cart");
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Key.Id.Equals(id))
                    return i;
            return -1;
        }

    }
}
