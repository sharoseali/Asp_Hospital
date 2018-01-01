using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Patient_Doctor_Application.Models
{
    public class Patient_Doctor_ApplicationContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Patient_Doctor_ApplicationContext() : base("name=Patient_Doctor_ApplicationContext")
        {
        }

        public System.Data.Entity.DbSet<Patient_Doctor_Application.Models.Patient> Patients { get; set; }

        public System.Data.Entity.DbSet<Patient_Doctor_Application.Models.Doctor> Doctors { get; set; }

        public System.Data.Entity.DbSet<Patient_Doctor_Application.Models.Appointments> Appointments { get; set; }
    }
}
