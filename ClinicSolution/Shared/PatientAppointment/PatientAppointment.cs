using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicSolution.Shared.PatientAppointment
{
    public class PatientAppointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string PatientName { get; set; }
        public string AccountOrAreaName { get; set; }
        public DateTime AppointmentDate { get; set; } = new DateTime();
        [Required]
        public string Complaints { get; set; }
        public string ClinicalMedicine { get; set; }
        public string FirstPrescription { get; set; }
        public string SecondPrescription { get; set; }
        public string Specification { get; set; }
        public DateTime CreatedDate { get; set; } = new DateTime();
        
    }
}
