using Donation_Domain.entities;
using Donation_Infrastructure.Ddcontext;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace donation_api.Controllers
{
  
    [ApiController]
    [Route("api/[controller]")]
    public class BeneficiariesController : ControllerBase
    {
        private readonly BeneficiarieContext _Context;

        public BeneficiariesController(BeneficiarieContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Beneficiarie>> GetBeneficiaries()
        {
            var beneficiaries = _Context.beneficiarie.ToList();
            return Ok(beneficiaries);
        }

        [HttpGet("{id}")]
        public ActionResult<Beneficiarie> GetBeneficiary(int id)
        {
            var beneficiary = _Context.beneficiarie.Find(id);

            if (beneficiary == null)
            {
                return NotFound();
            }

            return Ok(beneficiary);
        }

        [HttpPost]
        public ActionResult<Beneficiarie> CreateBeneficiary(Beneficiarie model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _Context.beneficiarie.Add(model);
            _Context.SaveChanges();

            return CreatedAtAction(nameof(GetBeneficiary), new { id = model.id_Benefi }, model);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBeneficiary(int id, Beneficiarie model)
        {
            if (id != model.id_Benefi)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingBeneficiary = _Context.beneficiarie.Find(id);
            if (existingBeneficiary == null)
            {
                return NotFound();
            }

            _Context.Entry(existingBeneficiary).CurrentValues.SetValues(model);

            try
            {
                _Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficiaryExists(id))
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
        public IActionResult DeleteBeneficiary(int id)
        {
            var beneficiary = _Context.beneficiarie.Find(id);
            if (beneficiary == null)
            {
                return NotFound();
            }

            _Context.beneficiarie.Remove(beneficiary);
            _Context.SaveChanges();

            return NoContent();
        }

        private bool BeneficiaryExists(int id)
        {
            return _Context.beneficiarie.Any(e => e.id_Benefi == id);
        }
    }
}