using ClinicSolution.Shared.Appointment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicSolution.Server.IService
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAllAppointments();
        Task<Appointment> GetAppointmentById(int id);
        Task<int> CreateAppointment(Appointment model);
        Task UpdateAppointment(Appointment model);
        Task DeleteAppointment(int id);
    }
}
