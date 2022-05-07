using ApplicantAssessmentSystem.App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantAssessmentSystem.App.Repository
{
    public interface IQuestionRepository : IBaseRepository<Question>
    {
        Task<Question> GetQuestionBySubjectAndNumber(string subject, int number);

        Task<List<Question>> GetQuestionBySubject(string subject);
    }
}
