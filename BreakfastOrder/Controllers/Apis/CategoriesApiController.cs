using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BreakfastOrder.Models.EFModels;
using BreakfastOrder.Models.ViewModels;

namespace BreakfastOrder.Controllers.Apis
{
    [RoutePrefix("api/Categoriesapi")]
    public class CategoriesApiController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            var db = new AppDbContext();

            var data = db.ProductCategories
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new ProductCategoryVm
                {
                    Id = x.Id,
                    Name = x.Name,
                    DisplayOrder = (int)x.DisplayOrder,
                    Image = x.Image
                })
                .ToList();
            return Ok(data);

        }


        public IHttpActionResult Get(int id)
        {
            var db = new AppDbContext();

            var Category = db.ProductCategories
                .AsNoTracking()
                //.Include(c => c.Products)
                .First(c => c.Id == id);

            if (Category == null)   
            {
                return NotFound();
            }
            var data = new

            {
                Category.Id,
                Category.Name,
                Category.DisplayOrder,
                Category.Image,

                Products = Category
                .Products
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Price,
                })
                .ToList()
            };

            return Ok(data);

        }

    }
}
