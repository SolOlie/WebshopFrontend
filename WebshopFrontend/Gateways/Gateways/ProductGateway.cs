using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;
using WebshopFrontend.Gateways.Interface;
using WebshopFrontend.Gateways.Other;

namespace WebshopFrontend.Gateways.Gateways
{
    public class ProductGateway : IProductGateway
    {
        public Product Create(Product t)
        {
            var Product = WebApiService.instance.PostAsync<Product>("/api/Product/PostProduct", t, HttpContext.Current.User.Identity.Name).Result;
            return Product;
        }

        public bool Delete(Product t)
        {
            var Product = WebApiService.instance.DeleteAsync<Product>("/api/Product/DeleteProduct/" + t.Id, HttpContext.Current.User.Identity.Name).Result;
            return Product;
        }

        public Product GetDefaultproduct()
        {
            throw new NotImplementedException();
        }

        public Product Read(int id)
        {
            var Product = WebApiService.instance.GetAsync<Product>("/api/Product/GetProduct/" + id, HttpContext.Current.User.Identity.Name).Result;
            return Product;
        }

        public List<Product> ReadAll()
        {
            var Products = WebApiService.instance.GetAsync<List<Product>>("/api/Product/GetProducts", HttpContext.Current.User.Identity.Name).Result ?? new List<Product>();
            return Products;
        }

        public bool Update(Product t)
        {
            var Product = WebApiService.instance.PutAsync<Product>("/api/Product/PutProduct/" + t.Id, t, HttpContext.Current.User.Identity.Name).Result;
            return Product;
        }
    }
}