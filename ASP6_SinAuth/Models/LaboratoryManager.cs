using ASP6_SinAuth.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP6_SinAuth.Models
{
    [Table("LaboratoryManagers")]
    public class LaboratoryManager: User
    {
        [Required]
        [PersonalData]
        public string FirstName { get; set; }

        [Required]
        [PersonalData]
        public string LastName { get; set; }

        [Required]
        [PersonalData]
        public string NationalID { get; set; }

        [Required]
        [PersonalData]
        public string CompanyAddress { get; set; }


    }
}
