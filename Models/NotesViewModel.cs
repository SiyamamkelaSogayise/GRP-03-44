using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeeksProject02.Areas.Identity.Data;

namespace GeeksProject02.Models
{
    public class NotesViewModel
    {
        public GeeksProject02User UserDetails { get; set; }
        public GeeksProject02User UserStatus { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]

        public string subject { get; set; }
        [Required]

        public string Message { get; set; }
        public string userId { get; set; }
    }
}
