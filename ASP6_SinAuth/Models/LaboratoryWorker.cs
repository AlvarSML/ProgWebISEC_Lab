using ASP6_SinAuth.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP6_SinAuth.Models
{
    [Table("Laboratory_workers")]
    public class LaboratoryWorker : User
    {
        [Column("id_lab")]
        public Laboratory? laboratory { get; set; }
    }
}
