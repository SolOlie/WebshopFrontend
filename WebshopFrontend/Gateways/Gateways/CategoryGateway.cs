using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebshopFrontend.Gateways.Interface;
using WebshopFrontend.Gateways.Other;

namespace WebshopFrontend.Gateways.Gateways
{
    public class CategoryGateway : IServiceGateway<Category>
    {
        public Category Create(Category t)
        {
            var Category = WebApiService.instance.PostAsync<Category>("/api/Category/PostCategory", t, HttpContext.Current.User.Identity.Name).Result;
            return Category;
        }

        public bool Delete(Category t)
        {
            var Category = WebApiService.instance.DeleteAsync<Category>("/api/Category/DeleteCategory/" + t.Id, HttpContext.Current.User.Identity.Name).Result;
            return Category;
        }

        public Category Read(int id)
        {
            var Category = WebApiService.instance.GetAsync<Category>("/api/Category/GetCategory/" + id, HttpContext.Current.User.Identity.Name).Result;
            return Category;
        }

        public List<Category> ReadAll()
        {
            var Category = WebApiService.instance.GetAsync<List<Category>>("/api/Category/GetCategories", HttpContext.Current.User.Identity.Name).Result ?? new List<Category>();
            return Category;
        }

        public bool Update(Category t)
        {
            var Category = WebApiService.instance.PutAsync<Category>("/api/Category/PutCategory/" + t.Id, t, HttpContext.Current.User.Identity.Name).Result;
            return Category;
        }
    }
}