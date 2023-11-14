using GeeksProject02.Data;
using Microsoft.EntityFrameworkCore;

namespace GeeksProject02.Models
{
    public class ReportService
    {
        private readonly GeeksProject02Context _dbContext;

        public ReportService(GeeksProject02Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MostBookedVaccineReportModel>> GetMostBookedVaccinesAsync()
        {
            return await _dbContext.Lasts
                .GroupBy(l => l.SelectedVaccine)
                .Select(g => new MostBookedVaccineReportModel
                {
                    VaccineName = g.Key,
                    BookingCount = g.Count()
                })
                .OrderByDescending(m => m.BookingCount)
                .Take(10)  // Optional: Get top 10 most booked vaccines
                .ToListAsync();
        }
    }
}
