#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using carCRBackend.Contexts;
using carCRBackend.Models;

namespace carCRBackend.Controllers
{
    //**************************************************
    //Automatically generated using SQLite context
    //**************************************************

    [Route("api/[controller]")]
    [ApiController]
    public class CarDataController : ControllerBase
    {
        private readonly CarDataSQLiteDbContext _context;

        public CarDataController(CarDataSQLiteDbContext context)
        {
            _context = context;
        }

        // GET: api/CarData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDataModel>>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        // GET: api/CarData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDataModel>> GetCarDataModel(int id)
        {
            var carDataModel = await _context.Cars.FindAsync(id);

            if (carDataModel == null)
            {
                return NotFound();
            }

            return carDataModel;
        }

        // PUT: api/CarData/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarDataModel(int id, CarDataModel carDataModel)
        {
            if (id != carDataModel.CarId)
            {
                return BadRequest();
            }

            _context.Entry(carDataModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarDataModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CarData
        [HttpPost]
        public async Task<ActionResult<CarDataModel>> PostCarDataModel(CarDataModel carDataModel)
        {
            _context.Cars.Add(carDataModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarDataModel", new { id = carDataModel.CarId }, carDataModel);
        }

        // DELETE: api/CarData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarDataModel(int id)
        {
            var carDataModel = await _context.Cars.FindAsync(id);
            if (carDataModel == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(carDataModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarDataModelExists(int id)
        {
            return _context.Cars.Any(e => e.CarId == id);
        }
    }
}
