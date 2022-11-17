using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AppointmentQueriesRepository : IAppointmentQueriesRepository
    {
        private AppointmentDbContext _dbContext;
        public AppointmentQueriesRepository(AppointmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Appointment GetLastAppointment()
        {
            return _dbContext.Appointments.OrderBy(x => x.Id).LastOrDefault();
        }
    }
}
