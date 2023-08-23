using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeeksProject02.Models
{
    public class MedicalAidModel: PageModel
    {
        
        public string MedicalAidName { get; set; }
        public int MedicalAidNumber { get; set; }
        public string TypeOfVaccine { get; set; }
    }
}
