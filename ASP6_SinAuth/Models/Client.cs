using ASP6_SinAuth.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP6_SinAuth.Models
{
    [Table("Clients")]
    public class Client : User
    {
        [PersonalData]
        [Range(0,130)]
        public int age { get; set; }

        [PersonalData]
        [Required]
        public Boolean Sex { get; set; }
    }
}
