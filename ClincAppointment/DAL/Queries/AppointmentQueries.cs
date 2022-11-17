using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Queries
{
    public  class AppointmentQueries : IAppointmentQueries
    {
        private readonly IAppointmentQueriesRepository _repository;

        public AppointmentQueries(IAppointmentQueriesRepository repository)
        {
            _repository= repository;
        }
        public Appointment GetLastAppointment()
        {
            return _repository.GetLastAppointment();
        }
    }
}
