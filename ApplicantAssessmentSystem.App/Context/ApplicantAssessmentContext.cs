using ApplicantAssessmentSystem.App.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicantAssessmentSystem.App.Context
{
    public class ApplicantAssessmentContext : DbContext
    {
        public ApplicantAssessmentContext(DbContextOptions<ApplicantAssessmentContext> options)
            : base(options)
        {

        }

        public DbSet<Applicant> Applicant { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<ApplicantAnswerSummary> ApplicantAnswerSummary { get; set; }
        public DbSet<ApplicantAnswerDetails> ApplicantAnswerDetails { get; set; }

        public DbSet<Transfer> Transfer { get; set; }
    }
}
