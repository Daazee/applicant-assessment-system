using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicantAssessmentSystem.App.Models.ViewModels
{
    public class TransferViewModel
    {
        public int TransferId { get; set; }

        public int ApplicantId { get; set; }

        public string ApplicantFullName { get; set; }

        public decimal ApplicantTotalScore { get; set; }

        public decimal TotalObtainable { get; set; }

        public decimal Percentage { get; set; }
    }
}
