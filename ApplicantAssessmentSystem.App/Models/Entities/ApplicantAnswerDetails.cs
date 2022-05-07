using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicantAssessmentSystem.App.Models.Entities
{
    public class ApplicantAnswerDetails
    {
        public int ApplicantAnswerDetailsId { get; set; }
        public int ApplicantAnswerSummaryId { get; set; }
        public int SessionId { get; set; }

        public int QustionNumber { get; set; }

        public int Score { get; set; }

        public int ApplicantId { get; set; }
    }
}
