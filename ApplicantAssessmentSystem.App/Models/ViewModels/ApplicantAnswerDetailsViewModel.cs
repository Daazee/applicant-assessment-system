using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicantAssessmentSystem.App.Models.ViewModels
{
    public class ApplicantAnswerDetailsViewModel
    {
        public int ApplicantAnswerDetailsId { get; set; }
        public int ApplicantAnswerSummaryId { get; set; }
        public int SessionId { get; set; }

        public int QuestionNumber { get; set; }

        public int Score { get; set; }

        public int ApplicantId { get; set; }

        public string SelectedAnswer { get; set; }
        public string Subject { get; set; }
    }
}
