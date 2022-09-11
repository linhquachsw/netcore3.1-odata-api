using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Netpower.Contracts.Data;
using Netpower.Contracts.Data.Repositoties;
using Netpower.Migrations.Entities;

namespace Netpower.WebApi.Controllers.OData.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("odata/v{v:apiVersion}")]
    public class ProductsController : ODataController
    {
        private readonly IProductRepository _productRepo;
        private readonly IProductRatingRepository _productRatingRepo;
        private IUnitOfWork _unitofwork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _productRepo = unitOfWork.Products;
            _productRatingRepo = unitOfWork.ProductRating;
            _unitofwork = unitOfWork;
        }

        [EnableQuery]
        [MapToApiVersion("1.0")]
        [HttpGet, Route("Products")]
        [HttpGet, Route("Products/$count")]
        public IActionResult Get()
        {
            var result = _productRepo.GetAll().AsQueryable();
            return Ok(result);
        }

        [EnableQuery]
        [MapToApiVersion("1.0")]
        [HttpGet, Route("Products/{key}")]
        public SingleResult<Product> GetById(int key)
        {
            var result = _productRepo.GetProductById(key);
            return SingleResult.Create(result);
        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        public IActionResult MostExpensive()
        {
            var product = _productRepo.GetAll().Max(x => x.Price);
            return Ok(product);
        }

        // [MapToApiVersion("1.0")]
        // [HttpGet, Route("GetSalesTaxRate(PostalCode={postalCode})")]
        // public IActionResult GetSalesTaxRate([FromODataUri] int postalCode)
        // {
        //     double rate = 5.6;  // Use a fake number for the sample.
        //     return Ok(rate);
        // }

        [MapToApiVersion("1.0")]
        [HttpPost]
        public IActionResult Rate([FromODataUri] int key, ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            int rating = (int)parameters["Rating"];
            _productRatingRepo.Add(new ProductRating
            {
                ProductId = key,
                Rating = rating
            });

            try
            {
                _unitofwork.Commit();
            }
            catch (DbUpdateException e)
            {
                var ProductExists = _productRepo.GetProductById(key);
                if (ProductExists == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [EnableQuery]
        [MapToApiVersion("1.0")]
        [HttpPost, Route("Products")]
        public IActionResult Post([FromBody] Product product)
        {
            var result = _productRepo.Add(product);
            _unitofwork.Commit();
            return Created(result);
        }

        [EnableQuery]
        [MapToApiVersion("1.0")]
        [HttpPatch, Route("Products({key})")]
        public IActionResult Update(int key, Delta<Product> product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingProduct = _productRepo.Get(key);
            if (existingProduct == null) return NotFound();

            product.Patch(existingProduct);

            try
            {
                _unitofwork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Updated(existingProduct);
        }

        [EnableQuery]
        [MapToApiVersion("1.0")]
        [HttpDelete, Route("Products({key})")]
        public IActionResult Delete(int key)
        {
            Product existingProduct = _productRepo.Get(key);
            if (existingProduct == null) return NotFound();

            _productRepo.Delete(existingProduct.Id);
            _unitofwork.Commit();

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}