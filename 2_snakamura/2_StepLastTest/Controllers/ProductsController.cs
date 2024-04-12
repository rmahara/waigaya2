﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Waigaya2.Controllers.Request;
using Waigaya2.Controllers.Response;
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

            var response = new ProductEnrtyResponse
            {
                Product = p,
                Categories = _context.Categories.ToList(),
            };

            return View("Views/Products/ProductEntry.cshtml", response);
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

        /// <summary>
        /// テスト用　保存
        /// </summary>
        /// <returns></returns>
        [Route("upsertdemo")]
        public IActionResult UpsertDemo()
        {
            var request = new SaveProduct
            {
                Name = "なまえ",
                Description = "せつめい",
                Price = 100,
                CategoryId = 1
            };
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
            //return RedirectToAction(nameof(Index));
            return Ok();
        }

        /// <summary>
        /// テスト用　削除
        /// </summary>
        /// <returns></returns>
        [Route("deletedemo")]
        public IActionResult DeleteDemo()
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == 6);

            if (product != null)
            {

                product.DeleteAt = DateTime.Now;

                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            //return RedirectToAction(nameof(Index));
            return Ok();
        }
    }
}
