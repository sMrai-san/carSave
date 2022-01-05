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
    //Automatically generated GET, PUT, POST, DELETE using SQLite context
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

        //********************************
        //Get all cars
        //********************************
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDataModel>>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        //********************************
        //Get one car
        //********************************
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

        //********************************
        //Edit car
        //********************************
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

        //********************************
        //Add car
        //********************************
        [HttpPost]
        public async Task<ActionResult<CarDataModel>> PostCarDataModel(CarDataModel carDataModel)
        {
            _context.Cars.Add(carDataModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarDataModel", new { id = carDataModel.CarId }, carDataModel);
        }

        //********************************
        //Delete car
        //********************************
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
