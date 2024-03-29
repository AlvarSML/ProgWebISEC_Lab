﻿using ASP6_SinAuth.Areas.Identity.Data;
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

        [Required]
        [Column("creation_date")]
        public DateTime creationDate { get; set; }

        [Column("test_date")]
        [Required(ErrorMessage ="Please add a testing date")]
        public DateTime testDate { get; set; }

        public int? result { get; set; }

        [Column("client_id")]
        [Required]
        public User client{ get; set; }

        [Required]
        [Column("type_id")]
        public TestType type { get; set; }

        [Required]
        [Column("laboratory_id")]
        public Laboratory laboratory { get; set; }

        [Column("technician_id")]
        public User? technician { get; set; }

    }
}
