using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ASP6_SinAuth.Models;
using Microsoft.AspNetCore.Identity;

namespace ASP6_SinAuth.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Usuario class
[Table("Users")]
public class User : IdentityUser
{   
    // Personal data se elimina si el usuario pide su eliminacion
    [PersonalData]
    [Required]
    public string Name { get; set; }

    [PersonalData]
    public DateTime DOB { get; set; }

    
}

