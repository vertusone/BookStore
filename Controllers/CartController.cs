using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        StoreContext db;

        public async Task<IActionResult> Index()
        {
            List<Purchase> purchases = await db.Purchases.ToListAsync();
            
            return View(purchases);
        }
    }
}