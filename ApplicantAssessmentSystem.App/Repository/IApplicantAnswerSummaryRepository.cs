using ApplicantAssessmentSystem.App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantAssessmentSystem.App.Repository
{
    public interface IApplicantAnswerSummaryRepository : IBaseRepository<ApplicantAnswerSummary>
    {
        Task<List<ApplicantAnswerSummary>> GetTestScoreByApplicantId(int applicantId);
    }
}
