using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicantAssessmentSystem.App.Context
{
    public class ContextManager
    {
        public ContextManager(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration;

        public static ApplicantAssessmentContext GetContext()
        {
            //var connectionstring = Configuration.GetConnectionString("QueuingSystemContext");
            var connectionstring = "data source=localhost; Initial Catalog=assessment; Integrated Security=True;";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicantAssessmentContext>();
            optionsBuilder.UseSqlServer(connectionstring);
            ApplicantAssessmentContext context = new ApplicantAssessmentContext(optionsBuilder.Options);
            return context;
        }
    }
}
