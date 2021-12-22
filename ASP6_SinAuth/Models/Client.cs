using ASP6_SinAuth.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP6_SinAuth.Models
{
    [Table("Clients")]
    public class Client : User
    {
        [Range(0,130)]
        public int age { get; set; }
    }
}
