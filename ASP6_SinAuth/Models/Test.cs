using ASP6_SinAuth.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP6_SinAuth.Models
{
    

    [Table("Tests")]
    public class Test
    {
        public int Id { get; set; }
        public string? description { get; set; }

        [Timestamp]
        [Required]
        public DateTime creation_date { get; set; }
        public DateTime test_time { get; set; }
        public int result { get; set; }
        [Required]
        public User client { get; set; }

    }
}
