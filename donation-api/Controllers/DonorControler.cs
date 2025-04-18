using Donation_Domain.entities;
using Donation_Infrastructure.Ddcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace project_donation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorsController : ControllerBase
    {
        private readonly donorContext _Context;

        public DonorsController(donorContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Donor>> GetDonors()
        {
            var donors = _Context.donor.ToList();
            return Ok(donors);
        }

        [HttpGet("{id}")]
        public ActionResult<Donor> GetDonor(int id)
        {
            var donor = _Context.donor.Find(id);

            if (donor == null)
            {
                return NotFound();
            }

            return Ok(donor);
        }

        [HttpPost]
        public ActionResult<Donor> CreateDonor(Donor model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _Context.donor.Add(model);
            _Context.SaveChanges();

            return CreatedAtAction(nameof(GetDonor), new { id = model.id_donor }, model);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDonor(int id, Donor model)
        {
            if (id != model.id_donor)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingDonor = _Context.donor.Find(id);
            if (existingDonor == null)
            {
                return NotFound();
            }

            _Context.Entry(existingDonor).CurrentValues.SetValues(model);

            try
            {
                _Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonorExists(id))
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

        [HttpDelete("{id}")]
        public IActionResult DeleteDonor(int id)
        {
            var donor = _Context.donor.Find(id);
            if (donor == null)
            {
                return NotFound();
            }

            _Context.donor.Remove(donor);
            _Context.SaveChanges();

            return NoContent();
        }

        private bool DonorExists(int id)
        {
            return _Context.donor.Any(e => e.id_donor == id);
        }
    }
}