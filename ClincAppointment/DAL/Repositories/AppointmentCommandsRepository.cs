using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AppointmentCommandsRepository : IAppointmentCommandsRepository
    {
        private AppointmentDbContext _dbContext;
        public AppointmentCommandsRepository(AppointmentDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public void SaveAppointment(Appointment appointment)
        {
            _dbContext.Set<Appointment>().Add(appointment);

            _dbContext.SaveChanges();
        }
    }
}
