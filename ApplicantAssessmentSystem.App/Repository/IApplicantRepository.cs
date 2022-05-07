using ApplicantAssessmentSystem.App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantAssessmentSystem.App.Repository
{
    public interface IApplicantRepository : IBaseRepository<Applicant>
    {
        Task<Applicant> GetApplicantByUsername(string username);
    }
}
