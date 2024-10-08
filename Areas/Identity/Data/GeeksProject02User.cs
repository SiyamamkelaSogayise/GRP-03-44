﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GeeksProject02.Areas.Identity.Data;

// Add profile data for application users by adding properties to the GeeksProject02User class
public class GeeksProject02User : IdentityUser
{
    [Required]
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }
    [Required]
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }

    [NotMapped]
    public string Email { get; set; }
    //[Required]
    //public string Status { get; set; }
    
}

