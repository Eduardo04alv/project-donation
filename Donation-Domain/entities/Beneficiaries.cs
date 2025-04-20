using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation_Domain.entities
{
    [Table("Beneficiaries")]
    public class Beneficiarie
    {
        [Key]
        public int id_Benefi { get; set; }
        public string name_Benefi { get; set; }
        public string phone_Benefi { get; set; }
        public string website { get; set; }
        public string description { get; set; }
    }
}
