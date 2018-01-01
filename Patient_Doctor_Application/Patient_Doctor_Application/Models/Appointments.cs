using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Patient_Doctor_Application.Models
{
    public class Appointments
    {
        public int ID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }

        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime AppointmentTime { get; set; }
        public Doctor DoctorObj { get; set; }
        public Patient PatientObj { get; set; }
    }
}