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
            //var connectionstring = "data source=localhost; Initial Catalog=assessment; Integrated Security=True;";
            string connectionstring = Configuration.GetConnectionString("DefaultConnection");





            //var optionsBuilder = new DbContextOptionsBuilder<ApplicantAssessmentContext>();
            //optionsBuilder.UseSqlServer(connectionstring);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicantAssessmentContext>();
            optionsBuilder.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring));


            ApplicantAssessmentContext context = new ApplicantAssessmentContext(optionsBuilder.Options);

            //services.AddDbContextPool<MyDBContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            return context;
        }
    }
}
