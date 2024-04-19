﻿using ClinicSolution.Shared.Appointment;
using ClinicSolution.Shared.Disease;
using ClinicSolution.Shared.Patient;
using ClinicSolution.Shared.PatientAppointment;
using Microsoft.EntityFrameworkCore;

namespace ClinicSolution.Server.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public virtual DbSet<PatientAppointment> PatientAppointments { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }

    }
}
