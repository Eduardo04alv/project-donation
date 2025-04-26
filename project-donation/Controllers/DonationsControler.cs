using Donation_Infrastructure.Ddcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using project_donation.context.Donation;
using project_donation.Models.donations;


namespace project_donation.Controllers.donations
{
    public class DonationsController : Controller 
    {
        private readonly DonationsContext _Context;
        private readonly donorContext donor_Context;
        private readonly BeneficiarieContext benefi_Context;

        public DonationsController(DonationsContext context, donorContext donorCtx, BeneficiarieContext benefiCtx)
        {
            _Context = context;
            donor_Context = donorCtx;
            benefi_Context = benefiCtx;
        }

        public IActionResult Index()
        {
            var _donations = _Context.donations.ToList();
            return View(_donations);
        }

        public IActionResult Create()
        {
            ViewBag.Donors = new SelectList(donor_Context.donor.ToList(), "id_donor", "name_donor");
            ViewBag.Beneficiaries = new SelectList(benefi_Context.beneficiarie.ToList(), "id_Benefi", "name_Benefi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Donations model)
        {
            _Context.donations.Add(model);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var _donations = _Context.donations.Find(id);
            if (_donations == null)
            {
                return NotFound();
            }
            return View(_donations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Donations model)
        {
            if (id != model.d_donation)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _Context.donations.Update(model);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var _donations = _Context.donations.Find(id);
            if (_donations == null)
            {
                return NotFound();
            }
            return View(_donations);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var _donations = _Context.donations.Find(id);
            if (_donations == null)
            {
                return NotFound();
            }
            _Context.donations.Remove(_donations);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}