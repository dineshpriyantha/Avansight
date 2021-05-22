using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Avansight.Domain
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Range(20, 100)]
        public int Age { get; set; }
        public string Gender { get; set; }
        public virtual TreatmentReading TreatmentReading { get; set; }
    }
}
