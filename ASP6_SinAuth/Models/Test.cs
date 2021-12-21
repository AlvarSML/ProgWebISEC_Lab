using ASP6_SinAuth.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP6_SinAuth.Models
{


    [Table("Tests")]
    public class Test
    {
        [Column("id_test")]
        public int Id { get; set; }
        public string? description { get; set; }

        [Timestamp]
        [Required]
        [Column("creation_date")]
        public DateTime creationDate { get; set; }

        [Column("test_date")]
        public DateTime testDate { get; set; }

        public int result { get; set; }

        [Column("client_id")]
        public User client{ get; set; }

        [Required]
        [Column("type_id")]
        public TestType type { get; set; }


        [Column("technician_id")]
        public User technician { get; set; }

    }
}
