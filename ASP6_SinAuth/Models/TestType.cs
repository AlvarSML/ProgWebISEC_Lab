using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP6_SinAuth.Models
{
    [Table("test_types")]
    public class TestType
    {
        [Key]
        [Column("id_type")]
        public int Id { get; set; }
        [Column("title_type")]
        public string type { get; set; }
        
        public string description { get; set; }

    }
}
