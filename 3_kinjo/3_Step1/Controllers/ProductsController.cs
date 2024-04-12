﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Waigaya2.Controllers.Request;
using Waigaya2.Data;
using Waigaya2.Models;

namespace Waigaya2.Controllers
{
    [Route("products")]
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

        /// <summary>
        /// 商品マスタ 登録
        /// </summary>
        /// <param name="id">修正の場合、設定</param>
        /// <returns></returns>
        [Route("product_entry")]
        [Route("product_entry/{id}")]
        public IActionResult Entry(int? id)
        {
            Product? p = null;
            if (id != null) 
            {
                 p = _context.Products.FirstOrDefault(x => x.Id == id);
            }

            return View("Views/Products/ProductEntry.cshtml", p);
        }

        /// <summary>
        /// 商品マスタ保存
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("upsert")]
        public IActionResult Upsert([FromForm] SaveProduct request)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == request.Id);

            if (product == null)
            {
                _context.Products.Add(new Product
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    CategoryId = request.CategoryId
                });
            }
            else
            {
                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                product.CategoryId = request.CategoryId;
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(ProductList));
        }

        /// <summary>
        /// 商品マスタ削除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("delete")]
        public IActionResult Delete([FromForm] SaveProduct request)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == request.Id);

            if (product != null)
            {
                product.DeleteAt = DateTime.Now;

                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(ProductList));
        }
    }
}
