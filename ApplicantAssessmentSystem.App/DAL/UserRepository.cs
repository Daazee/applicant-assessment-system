using ApplicantAssessmentSystem.App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicantAssessmentSystem.App.Repository;
using ApplicantAssessmentSystem.App.Context;

namespace ApplicantAssessmentSystem.App.DAL
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private ApplicantAssessmentContext context;
        public UserRepository(ApplicantAssessmentContext context) : base(context)
        {
            this.context = context;
        }


        //ApplicantAssessmentContext context = ContextManager.GetContext();
        public async Task<User> GetUserByUsername(string username)
        {
            User user = context.User.Where(c => c.Username == username).FirstOrDefault();
            return await Task.FromResult(user);
        }


    }
}
