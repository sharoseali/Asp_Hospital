using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Patient_Doctor_Application.Models
{
    public class Patient
    {
         public int ID { get; set; }

        [Display(Name = "Patient Name")]
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobileNumber { get; set; }
        public string E_mail { get; set; }
        public string address { get; set; }
        public string city { get; set; }
    }
}