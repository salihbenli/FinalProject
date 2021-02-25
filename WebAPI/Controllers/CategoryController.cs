using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("getall")]

        public IActionResult GetAll()
        {

            var result = _categoryService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        //public List<Product> Get()
        //{

        //    var result = _productService.GetAll();
        //    return result.Data;
        //    //IProductService productService = new ProductManager(new EfProductDal());
        //    //var result = productService.GetAll();
        //    //return result.Data;

        //    //return new List<Product>
        //    //{
        //    //    new Product{ProductId=1, ProductName="elma"},
        //    //    new Product{ProductId=2,ProductName="muz"}
        //    //};
        //}
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {

            var result = _categoryService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
