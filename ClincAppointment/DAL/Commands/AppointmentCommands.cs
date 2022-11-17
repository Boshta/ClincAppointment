using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Commands
{
    public class AppointmentCommands: IAppointmentCommands
    {
        private readonly IAppointmentCommandsRepository _repository;
        public AppointmentCommands(IAppointmentCommandsRepository repository)
        {
            _repository = repository;
        }
        public Appointment SaveAppointmentData(Appointment appointment)
        {
            appointment.CreationDate = DateTime.Now;
            appointment.ModificationDate = DateTime.Now;

            _repository.SaveAppointment(appointment);
            return appointment;
        }
    }
}
