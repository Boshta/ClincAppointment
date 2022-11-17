using DAL.Commands;
using DAL.Models;
using DAL.Queries;
using System.ComponentModel.DataAnnotations;

namespace BL
{
    public class AppointmentBusinessLogic : IAppointmentBusinessLogic
    {
        IAppointmentCommands _commands;
        IAppointmentQueries _queries;

        public AppointmentBusinessLogic(IAppointmentCommands commands, IAppointmentQueries queries) 
        {
            _commands = commands;
            _queries = queries;
        }
        public Appointment AddAppointment(AppointmentDto appointment)
        {
            var newAppointment = new Appointment
            {
                PatientName = appointment.PatientName,
                Phone = appointment.Phone,
                Note = appointment.Note,
            };

            var lastAppointment = _queries.GetLastAppointment();
            if(lastAppointment == null)
            {
                newAppointment.AppointmentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 1, 0, 0);    
            }
            else
            {
                newAppointment.AppointmentDate = lastAppointment.AppointmentDate.AddHours(1);
            }

            return _commands.SaveAppointmentData(newAppointment);
        }
    }
}