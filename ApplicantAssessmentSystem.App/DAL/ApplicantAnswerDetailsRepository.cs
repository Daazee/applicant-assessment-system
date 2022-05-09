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
        public ApplicantAnswerDetailsRepository()
        {

        }



        ApplicantAssessmentContext context = ContextManager.GetContext();
    }
}
