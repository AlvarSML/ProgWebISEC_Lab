using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP6_SinAuth.Models
{
    public class Laboratory
    {
        [Column("id_laboratory")]
        public int Id { get; set; }
        [Column("name")]
        [Required]
        public string Name { get; set; }
        [Column("location")]
        public string Location { get; set; }
        [Column("phone")]
        public string? Phone { get; set; }

    }
}
