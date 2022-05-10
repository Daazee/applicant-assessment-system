using ApplicantAssessmentSystem.App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantAssessmentSystem.App.Repository
{
    public interface IApplicantAnswerDetailsRepository : IBaseRepository<ApplicantAnswerDetails>
    {
        Task<List<ApplicantAnswerDetails>> GetTestScoreByApplicantId(int applicantId);
        Task<IEnumerable<IGrouping<string, ApplicantAnswerDetails>>> GetTestScoreGroupByApplicantId(int applicantId);
    }
}
