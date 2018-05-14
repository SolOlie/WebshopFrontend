using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebshopFrontend.Gateways.Gateways;
using WebshopFrontend.Gateways.Interface;
using WebshopFrontend.Models;

namespace WebshopFrontend.Controllers
{
    public class ProductController : Controller
    {
        private IProductGateway productGateway = new ProductGateway();
        private CategoryGateway categoryGateway = new CategoryGateway();
        private ProductCategory pc = new ProductCategory();
        // GET: Product
        public ActionResult Index()
        {
            var model = productGateway.ReadAll();
            return View(model);
        }

        // GET: Product/Details/5
        public ActionResult Details(Product product)
        {
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.categoryList = GetCategories();
            return View(pc);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductCategory prca)
        {
            try
            {
                if (prca.category == null)
                {
                    return RedirectToAction("Index");
                }
                    productGateway.Create(new Product
                    {
                        ProductName = prca.product.ProductName,
                        Information = prca.product.Information,
                        Manufacture = prca.product.Manufacture,
                        Price = prca.product.Price,
                        CategoryId = prca.category.Id
                    });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(Product product)
        {
            ViewBag.categoryList = GetCategories();
            var lok = new ProductCategory
            {
                product = product
            };
            return View(lok);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                if (product != null)
                {
                    productGateway.Update(product);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var product = productGateway.Read(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            productGateway.Delete(product);
            return RedirectToAction("Index");
        }
        //POST: Product/PostCategory
        [HttpPost]
        public ActionResult PostCategory(string html)
        {
            try
            {
                if (html != null)
                {
                    categoryGateway.Create(new Category
                    {
                        CategoryName = html
                    });
                    return Json(new { success = true });
                }
                return Json(new { succes = false });
            }
            catch
            {
                return Json(new { succes = false });
            }

        }
        public IEnumerable<SelectListItem> GetCategories()
        {
            return new SelectList(categoryGateway.ReadAll(), "Id", "CategoryName", 1);
        }
    }
}
