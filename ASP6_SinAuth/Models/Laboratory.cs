using ASP6_SinAuth.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP6_SinAuth.Models
{
    public class Laboratory
    {
        [Key]
        [Column("id_laboratory")]
        public string IdLab { get; set; }
        [Column("name")]
        [Required]
        public string Name { get; set; }
        [Column("location")]
        public string Location { get; set; }
        [Column("phone")]
        public string? Phone { get; set; }

        [Column("LabOwnerId")]
        [ForeignKey("Id")]
        public virtual User LabOwner { get; set; }
    }
}
