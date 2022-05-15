using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicantAssessmentSystem.App.Models.Entities
{
    public class Transfer
    {
        public int TransferId { get; set; }

        public int ApplicantId { get; set; }

        public decimal ApplicantTotalScore { get; set; }

        public decimal TotalObtainable { get; set; }

        public decimal Percentage { get; set; }

    }
}
