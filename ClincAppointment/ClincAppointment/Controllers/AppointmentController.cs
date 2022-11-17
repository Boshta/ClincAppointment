using BL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClincAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        IAppointmentBusinessLogic _appointmentBusinessLogic;

        public AppointmentController(IAppointmentBusinessLogic appointmentBusinessLogic)
        {
            _appointmentBusinessLogic= appointmentBusinessLogic;
        }

        [HttpPost]
        public Appointment AddAppointment([FromBody] AppointmentDto appointmentDto)
        {
            return _appointmentBusinessLogic.AddAppointment(appointmentDto);
        }
    }
}
