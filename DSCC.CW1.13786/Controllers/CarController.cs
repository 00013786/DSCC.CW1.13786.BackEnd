using DSCC.CW1._13786.Model;
using DSCC.CW1._13786.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace DSCC.CW1._14610.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _CarRepository;
        public CarController(ICarRepository CarRepository)
        {
            _CarRepository = CarRepository;
        }


        // GET: api/Cars
        [HttpGet]
        public IActionResult Get()
        {
            var Cars = _CarRepository.GetCars();
            return new OkObjectResult(Cars);
            //return new string[] { "value1", "value2" };
        }


        // GET: api/Cars/5
        [HttpGet("{id}", Name = "GetCarById")]
        public IActionResult Get(int id)
        {
            var Car = _CarRepository.GetCarById(id);
            if (Car != null)
            {
                return new OkObjectResult(Car);
            }
            return new NoContentResult();
            //return "value";
        }

        // POST: api/Cars
        [HttpPost]
        public IActionResult Post([FromBody] Car Car)
        {
            using (var scope = new TransactionScope())
            {
                _CarRepository.InsertCar(Car);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = Car.Id }, Car);
            }
        }
        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Car Car)
        {
            if (Car != null)
            {
                using (var scope = new TransactionScope())
                {
                    _CarRepository.UpdateCar(Car);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _CarRepository.DeleteCar(id);
            return new OkResult();
        }

    }
}
