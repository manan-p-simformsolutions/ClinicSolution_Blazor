using ClinicSolution.Server.IRepository;
using ClinicSolution.Server.IService;
using ClinicSolution.Shared.Appointment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicSolution.Server.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<Appointment>> GetAllAppointments()
        {
            return await _appointmentRepository.GetAllAppointments();
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _appointmentRepository.GetById(id);
        }

        public async Task<int> CreateAppointment(Appointment appointment)
        {
            return await _appointmentRepository.Create(appointment);
        }

        public async Task UpdateAppointment(Appointment appointment)
        {
            await _appointmentRepository.Update(appointment);
        }

        public async Task DeleteAppointment(int id)
        {
            await _appointmentRepository.Delete(id);
        }
    }
}
