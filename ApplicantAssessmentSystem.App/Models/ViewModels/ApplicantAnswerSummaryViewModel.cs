using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicantAssessmentSystem.App.Models.ViewModels
{
    public class ApplicantAnswerSummaryViewModel
    {

        public int ApplicantAnswerSummaryId { get; set; }
        public int SessionId { get; set; }

        public int ApplicantId { get; set; }

        public int TotalObtainable { get; set; }
        public int ApplicantScore { get; set; }

        public string Subject { get; set; }

        public string ApplicantName { get; set; }
    }
}
