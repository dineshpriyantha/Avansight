using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Avansight.Domain
{
    public class TreatmentReading
    {
        [Key]
        public int TreatmentReadingId { get; set; }
        public string VisitWeek { get; set; }
        public decimal Reading { get; set; }
        public int PatientId { get; set; }        
    }
}
