using Donation_application.Iservices;
using Donation_Domain.entities;
using Microsoft.AspNetCore.Mvc;

namespace donation_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService _donorService;

        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var donors = await _donorService.GetAll();
            return Ok(donors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var donor = await _donorService.GetById(id);
            if (donor == null)
                return NotFound();

            return Ok(donor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Donor donor)
        {
            await _donorService.Add(donor);
            return Ok(new { message = "Donor created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Donor donor)
        {
            donor.id_donor = id;
            await _donorService.Update(donor);
            return Ok(new { message = "Donor updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _donorService.Delete(id);
            return Ok(new { message = "Donor deleted successfully" });
        }
    }
}