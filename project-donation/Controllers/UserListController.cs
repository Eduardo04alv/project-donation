using Microsoft.AspNetCore.Mvc;
using Donation_Infrastructure.IRepository;
using Donation_Domain.Repository; 

namespace project_donation.Controllers
{
    public class UserlistController : Controller
    {
        private readonly IDonorRepository _donorRepo;
        private readonly IBeneficiarieRepository _beneficiarieRepo;
        private readonly IDonationsRepository _donationsRepo;

        public UserlistController(IDonorRepository donorRepo, IBeneficiarieRepository beneficiarieRepo, IDonationsRepository donationsRepo)
        {
            _donorRepo = donorRepo;
            _beneficiarieRepo = beneficiarieRepo;
            _donationsRepo = donationsRepo;
        }

        public IActionResult Donor()
        {
            var donors = _donorRepo.Getall();
            return View(donors); 
        }

        public IActionResult Beneficiaries()
        {
            var beneficiaries = _beneficiarieRepo.Getall();
            return View(beneficiaries); 
        }

        public IActionResult Donations()
        {
            var donations = _donationsRepo.Getall();
            return View(donations); 
        }
    }
}