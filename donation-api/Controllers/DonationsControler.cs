using Microsoft.AspNetCore.Mvc;
using project_donation.context.Donation;
using project_donation.Models.donations;
using System.Data.Entity;


namespace project_donation.Controllers.donations
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationsController : ControllerBase
    {
        private readonly DonationsContext _context;

        public DonationsController(DonationsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Donations>> GetAll()
        {
            return Ok(_context.donations.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Donations> GetById(int id)
        {
            var donation = _context.donations.Find(id);
            if (donation == null)
                return NotFound();
            return Ok(donation);
        }

        [HttpPost]
        public ActionResult<Donations> Create(Donations model)
        {
            _context.donations.Add(model);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = model.d_donation }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Donations model)
        {
            if (id != model.d_donation)
                return BadRequest();

            if (!_context.donations.Any(d => d.d_donation == id))
                return NotFound();

            _context.Entry(model).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var donation = _context.donations.Find(id);
            if (donation == null)
                return NotFound();

            _context.donations.Remove(donation);
            _context.SaveChanges();
            return NoContent();
        }
    }
}