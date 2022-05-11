using ApplicantAssessmentSystem.App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicantAssessmentSystem.App.Repository;
using ApplicantAssessmentSystem.App.Context;

namespace ApplicantAssessmentSystem.App.DAL
{
    public class ApplicantRepository : BaseRepository<Applicant>, IApplicantRepository
    {
        private ApplicantAssessmentContext context;
        public ApplicantRepository(ApplicantAssessmentContext context) : base(context)
        {
            this.context = context;
        }


        //ApplicantAssessmentContext context = ContextManager.GetContext();

        public async Task<Applicant> GetApplicantByUsername(string username)
        {
            Applicant applicant = context.Applicant.Where(c => c.Username == username).FirstOrDefault();
            return await Task.FromResult(applicant);
        }

    }
}
