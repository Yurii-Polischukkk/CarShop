using CarMarket.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Repos
{
    public class SessionManager
    {
        private readonly CarMarketDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        private ISession _session => httpContextAccessor.HttpContext.Session;

        public SessionManager(CarMarketDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public void SetCartId(string id, string cartSessionKey)
        {
            _session.SetString(cartSessionKey, id);
        }

        public string GetCartId(string cartSessionKey)
        {
            if (!_session.Keys.Any(x => x == cartSessionKey))
            {
                if (!string.IsNullOrWhiteSpace(_session.Id))
                {
                    SetCartId(_session.Id, cartSessionKey);
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    SetCartId(tempCartId.ToString(), cartSessionKey);
                }
            }
            return _session.GetString(cartSessionKey);
        }
        public List<CartItem> GetCartItems()
        {
            var cart = _session.GetObject<List<CartItem>>("cart");
            return cart;
        }
    }
}
