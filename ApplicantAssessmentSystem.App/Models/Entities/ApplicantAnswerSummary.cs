using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicantAssessmentSystem.App.Models.Entities
{
    public class ApplicantAnswerSummary
    {

        public int ApplicantAnswerSummaryId { get; set; }
        public int SessionId { get; set; }

        public int ApplicantId { get; set; }
    }
}
