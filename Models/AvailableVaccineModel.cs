using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
    public class AvailableVaccine
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        
        public bool IsAvailable { get; set; }
        [Required]
        public DateTime? RestockDate { get; set; }
        
        
    }
}
