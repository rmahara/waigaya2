using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Waigaya2.Data;

namespace Waigaya2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly WaigayaDbContext _context;

        public ProductsController(WaigayaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 商品マスタ全件表示
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [Route("productlist")]
        public IActionResult ProductList()
        {
            var list = _context.Products.Include(p => p.Category).Where(p => p.DeleteAt == null).ToList();
            return View(list);
        }
    }
}
