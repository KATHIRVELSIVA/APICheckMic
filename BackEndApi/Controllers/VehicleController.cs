using BackEndApi.Data;
using BackEndApi.DTO;
using BackEndApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VehicleController(AppDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public ActionResult GetAllDetails()
        //{
        //    var blog = _context.VehicleModel
        //        .FromSql($"Select * From microproject.vehicleModel")
        //        .ToList();
        //    return Ok();
        //}

        // GET: api/Vehicle
        [HttpGet]
        public ActionResult<IEnumerable<VehicleModel>> GetVehicleUser(int userid)
        {
            var output = _context.VehicleModel
                 .FromSql($"Select * From microproject.vehicleModel where userid = {userid}")
                 .ToList();
            //return await _context.VehicleModel.ToListAsync();
            return Ok(output);
        }

        // GET: api/Vehicle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleModel>> GetVehicleModel(int id)
        {
            var vehicleModel = await _context.VehicleModel.FindAsync(id);
            
            
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return vehicleModel;
        }

        // PUT: api/Vehicle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleModel(int id, VehicleModel vehicleModel)
        {
            if (id != vehicleModel.VehicleId)
            {
                return BadRequest();
            }

            _context.Entry(vehicleModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleModelExists(id))
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

        // POST: api/Vehicle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VehicleModel>> PostVehicleModel(VehicleDTO vehicleDTO)
        {
            UserModel userModel = await _context.User.FindAsync(vehicleDTO.UserID);
            VehicleModel vehicleModel = new VehicleModel()
            {
                VehicleId = vehicleDTO.VehicleId,
                VehicleNo = vehicleDTO.VehicleNo,
                VehicleName = vehicleDTO.VehicleName,
                VehicleType = vehicleDTO.VehicleType,
                Location = vehicleDTO.Location,
                YearOfMake = vehicleDTO.YearOfMake,
                IDVvalue = vehicleDTO.IDVvalue,
                User = userModel
            };
            _context.VehicleModel.Add(vehicleModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleModel", new { id = vehicleModel.VehicleId }, vehicleModel);
        }

        // DELETE: api/Vehicle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleModel(int id)
        {
            var vehicleModel = await _context.VehicleModel.FindAsync(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            _context.VehicleModel.Remove(vehicleModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleModelExists(int id)
        {
            return _context.VehicleModel.Any(e => e.VehicleId == id);
        }
    }
}
