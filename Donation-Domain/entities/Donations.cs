using System.ComponentModel.DataAnnotations;

namespace project_donation.Models.donations
{
    public class Donations
    {
        [Key]
        public int d_donation { get; set; }
        public int id_donor { get; set; }
        public int id_Benefi { get; set; }
        public decimal amount { get; set; }
        public string type_donation { get; set; }
        public string date_donation { get; set; }
    }
}
