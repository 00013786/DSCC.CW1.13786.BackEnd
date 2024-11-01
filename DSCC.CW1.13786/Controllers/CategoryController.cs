using DSCC.CW1._13786.Model;
using DSCC.CW1._13786.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace DSCC.CW1._13786.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository _CategoryRepository;
        public CategoryController(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }


        // GET: CategoryController
        [HttpGet]
        public IActionResult Get()
        {
            var Categories = _CategoryRepository.GetCategories();
            return new OkObjectResult(Categories);
            //return new string[] { "value1", "value2" };
        }


        // GET: CategoryController/Details/5
        [HttpGet("{id}", Name = "GetCategoryById")]
        public IActionResult Get(int id)
        {
            var Category = _CategoryRepository.GetCategoryById(id);
            if (Category != null)
            {
                return new OkObjectResult(Category);
            }
            return new NoContentResult();
            //return "value";
        }

        // POST: CategoryController/Create
        [HttpPost]
        public IActionResult Post([FromBody] Category Category)
        {
            using (var scope = new TransactionScope())
            {
                _CategoryRepository.InsertCategory(Category);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = Category.Id }, Category);
            }
        }
        // PUT: CategoryController/Create
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category Category)
        {
            if (Category != null)
            {
                using (var scope = new TransactionScope())
                {
                    _CategoryRepository.UpdateCategory(Category);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        // POST: CategoryController/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _CategoryRepository.DeleteCategory(id);
            return new OkResult();
        }

    }
}