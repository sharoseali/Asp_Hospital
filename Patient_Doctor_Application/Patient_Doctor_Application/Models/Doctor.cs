using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Patient_Doctor_Application.Models
{
    public class Doctor
    {

        public int ID { get; set; }

        [Display(Name="Doctor Name")]
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string eMail { get; set; }
        public string mobileNumber { get; set; }
        public string city { get; set; }
    }
}