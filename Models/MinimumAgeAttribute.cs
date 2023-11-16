using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        public override bool IsValid(object value)
        {
            DateTime date;
            if(DateTime.TryParse(value.ToString(), out date))
            {
                return date.AddYears(_minimumAge) > DateTime.Now;
            }
            return false;
        }
    }
}
