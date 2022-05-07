using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicantAssessmentSystem.App.Models.ViewModels
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public int QuestionNumber { get; set; }
        public string Subject { get; set; }

        public string QuestionText { get; set; }

        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }

        public string Answer { get; set; }

        public int AttributedScore { get; set; }
    }
}
