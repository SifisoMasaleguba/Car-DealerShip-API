using Car_DealerShip_API.Data;
using Car_DealerShip_API.Model;
using Car_DealerShip_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Car_DealerShip_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository carRepository;

        public CarController( ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }


        [HttpGet]   
        public async Task<IEnumerable<Car>> Gets()
        {
            return await carRepository.Get();          

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Car), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Car>> GetCars(int id)
        {
            var car = await carRepository.Get(id);
            return car == null ? NotFound() : Ok(car);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Car>> PostCar([FromBody] Car car)
        {
            var Addedcar = await carRepository.Create(car);
            return CreatedAtAction(nameof(GetCars), new { id = Addedcar.Id }, Addedcar);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            await carRepository.Update(car);
            return NoContent();
        }


        [HttpGet("search/{name}")]
        [ProducesResponseType(typeof(Car), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Car>> GetCars(string name)
        {
            var car = await carRepository.SearchByName(name);
            return car == null ? NotFound() : Ok(car);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var carToDelete = await carRepository.Get(id);
            if (carToDelete == null)
                return NotFound();

            await carRepository.Delete(carToDelete.Id);
            return NoContent();
        }

    }
}
