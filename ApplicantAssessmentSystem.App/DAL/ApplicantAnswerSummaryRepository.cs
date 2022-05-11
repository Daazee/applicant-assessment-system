using ApplicantAssessmentSystem.App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicantAssessmentSystem.App.Repository;
using ApplicantAssessmentSystem.App.Context;

namespace ApplicantAssessmentSystem.App.DAL
{
    public class ApplicantAnswerSummaryRepository : BaseRepository<ApplicantAnswerSummary>, IApplicantAnswerSummaryRepository
    {
        private ApplicantAssessmentContext context;
        public ApplicantAnswerSummaryRepository(ApplicantAssessmentContext context) : base(context)
        {
            this.context = context;
        }


        //ApplicantAssessmentContext context = ContextManager.GetContext();

        public async Task<List<ApplicantAnswerSummary>> GetTestScoreByApplicantId(int applicantId)
        {
            var scores = context.ApplicantAnswerSummary.Where(c => c.ApplicantId == applicantId).ToList();
            return await Task.FromResult(scores);
        }
    }
}
