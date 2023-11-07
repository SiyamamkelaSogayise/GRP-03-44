using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
    public class AvailableVaccine
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public DateTime? RestockDate { get; set; }
        
        
    }
}
