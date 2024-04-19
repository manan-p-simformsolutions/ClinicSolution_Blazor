using ClinicSolution.Shared.Appointment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicSolution.Server.IRepository
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAllAppointments();
        Task<Appointment> GetById(int id);
        Task<int> Create(Appointment model);
        Task Update(Appointment model);
        Task Delete(int id);
    }
}
