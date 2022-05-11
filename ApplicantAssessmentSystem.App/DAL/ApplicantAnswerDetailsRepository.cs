using ApplicantAssessmentSystem.App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicantAssessmentSystem.App.Repository;
using ApplicantAssessmentSystem.App.Context;

namespace ApplicantAssessmentSystem.App.DAL
{
    public class ApplicantAnswerDetailsRepository : BaseRepository<ApplicantAnswerDetails>, IApplicantAnswerDetailsRepository
    {
        private ApplicantAssessmentContext context;
        public ApplicantAnswerDetailsRepository(ApplicantAssessmentContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<ApplicantAnswerDetails>> GetTestScoreByApplicantId(int applicantId)
        {
            var scores = context.ApplicantAnswerDetails.Where(c => c.ApplicantId == applicantId).OrderBy(c => c.Subject).ThenBy(c => c.QuestionNumber).ToList();
            return await Task.FromResult(scores);
        }

        public async Task<IEnumerable<IGrouping<string, ApplicantAnswerDetails>>> GetTestScoreGroupByApplicantId(int applicantId)
        {
            var query = context.ApplicantAnswerDetails.Where(c => c.ApplicantId == applicantId).OrderBy(c => c.Subject).ThenBy(c => c.QuestionNumber).AsEnumerable().GroupBy(c => c.Subject);
            return await Task.FromResult(query);
        }

       // ApplicantAssessmentContext context = ContextManager.GetContext();
    }
}
