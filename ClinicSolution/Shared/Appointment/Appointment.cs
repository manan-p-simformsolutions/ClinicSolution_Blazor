using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicSolution.Shared.Appointment
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PatientName { get; set; }
        public string Alias { get; set; }
        [Required]
        public string Problem { get; set; }
        public string ClinicalMedicine { get; set; }
        public string Prescription { get; set; }
        public string Specification { get; set; }
        public DateTime CreatedDate { get; set; } = new DateTime();
        public DateTime AppointmentDate { get; set; } = new DateTime();
        [Required]
        public double Amount { get; set; }
    }
}
