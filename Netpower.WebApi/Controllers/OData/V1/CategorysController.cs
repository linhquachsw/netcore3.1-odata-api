using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Netpower.Contracts.Data;
using Netpower.Contracts.Data.Repositoties;

namespace Netpower.WebApi.Controllers.OData.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("odata/v{v:apiVersion}")]
    public class CategorysController : ODataController
    {
        private readonly ICategoryRepository _categoryRepo;
        private IUnitOfWork _unitofwork;

        public CategorysController(IUnitOfWork unitOfWork)
        {
            _categoryRepo = unitOfWork.Categorys;
            _unitofwork = unitOfWork;
        }

        [EnableQuery]
        [MapToApiVersion("1.0")]
        [HttpGet, Route("Categorys")]
        [HttpGet, Route("Categorys/$count")]
        public IActionResult Get()
        {
            var result = _categoryRepo.GetAll().AsQueryable();
            return Ok(result);
        }
    }
}