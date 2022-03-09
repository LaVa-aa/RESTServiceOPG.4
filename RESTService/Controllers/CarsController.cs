using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarTest;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using RESTService.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private CarsManager manager = new CarsManager();
        // GET: api/<CarsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult< IEnumerable<Car>> Get([FromQuery]int maximumPrice)
        {
            IEnumerable<Car> resultCars = manager.GetAll(maximumPrice);
            if (resultCars.Count() == 0) return NoContent();

            return Ok(resultCars);
        }

        // GET api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Car> GetById(int id)
        {
            Car resultCar = manager.GetById(id);
            if (resultCar == null) return NotFound("No suvh car, id" + id);
            return Ok(resultCar);
        }

        // POST api/<CarsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car newCar)
        {
            Car resultCar = manager.AddCar(newCar);
            return Created($"/api/Cars/{resultCar.Id}", resultCar);
        }

        // DELETE api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
      
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            Car resultCar = manager.DeleteCar(id);
            if (resultCar == null) return NotFound("No such car, id: " + id);
            return Ok(resultCar);
        }
    }
}
