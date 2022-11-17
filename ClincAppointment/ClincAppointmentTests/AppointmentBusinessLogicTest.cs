using BL;
using DAL.Commands;
using DAL.Models;
using DAL.Queries;
using Moq;

namespace ClincAppointmentTests
{
    public class Tests
    {
        private Mock<IAppointmentCommands> _mockCommands;
        private Mock<IAppointmentQueries> _mockQueries;

        [SetUp]
        public void Setup()
        {
            _mockCommands = new Mock<IAppointmentCommands>();
            _mockQueries = new Mock<IAppointmentQueries>();
        }

        [Test]
        public void AddAppointment_WhenLastAppointmentIsNull_NewAppointmentDateISNow()
        {
            var newAppointment = new AppointmentDto()
            {
                PatientName = "Patient",
                Phone = "123456789"
            };

            var savedeAppointment = new Appointment()
            {
                PatientName = "Patient",
                Phone = "123456789",
                Id = 1,
                AppointmentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 1, 0, 0)
            };


            _mockQueries.Setup(x => x.GetLastAppointment()).Returns<Appointment>(null);
            _mockCommands.Setup(x => x.SaveAppointmentData(It.IsAny<Appointment>())).Returns(savedeAppointment);

            var businessLogic = new AppointmentBusinessLogic(_mockCommands.Object, _mockQueries.Object);

            var appointment = businessLogic.AddAppointment(newAppointment);

            Assert.IsNotNull(appointment);
            Assert.That(appointment.AppointmentDate, Is.EqualTo(savedeAppointment.AppointmentDate));
        }

        [Test]
        public void AddAppointment_WhenLastAppointmentIsNotNull_NewAppointmentDateISLastAppointmentDatePlusOneHoure()
        {
            var newAppointment = new AppointmentDto()
            {
                PatientName = "Patient",
                Phone = "123456789"
            };

            var lastAppointment = new Appointment()
            {
                PatientName = "Patient",
                Phone = "123456789",
                Id = 1,
                AppointmentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 1, 0, 0)
            };

            var savedeAppointment = new Appointment()
            {
                PatientName = "Patient",
                Phone = "123456789",
                Id = 1,
                AppointmentDate = lastAppointment.AppointmentDate.AddHours(1)
            };


            _mockQueries.Setup(x => x.GetLastAppointment()).Returns(lastAppointment);
            _mockCommands.Setup(x => x.SaveAppointmentData(It.IsAny<Appointment>())).Returns(savedeAppointment);

            var businessLogic = new AppointmentBusinessLogic(_mockCommands.Object, _mockQueries.Object);

            var appointment = businessLogic.AddAppointment(newAppointment);

            Assert.IsNotNull(appointment);
            Assert.That(appointment.AppointmentDate, Is.EqualTo(savedeAppointment.AppointmentDate));
        }
    }
}