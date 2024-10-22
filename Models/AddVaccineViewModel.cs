﻿using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
    public class AddVaccineViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Vaccine Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }
        [Required]
        [Display(Name = "Restock Date")]
        public DateTime? RestockDate { get; set; }


    }
}
