using ApplicantAssessmentSystem.App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicantAssessmentSystem.App.Repository;
using ApplicantAssessmentSystem.App.Context;

namespace ApplicantAssessmentSystem.App.DAL
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        private ApplicantAssessmentContext context;
        public QuestionRepository(ApplicantAssessmentContext context) : base(context)
        {
            this.context = context;
        }


        //ApplicantAssessmentContext context = ContextManager.GetContext();

        public async Task<Question> GetQuestionBySubjectAndNumber(string subject, int number)
        {
            Question question = context.Question.Where(c => c.Subject == subject && c.QuestionNumber == number).FirstOrDefault();
            return await Task.FromResult(question);
        }

        public async Task<List<Question>> GetQuestionBySubject(string subject)
        {
            var questions = context.Question.Where(c => c.Subject == subject).ToList();
            return await Task.FromResult(questions);
        }
    }
}
