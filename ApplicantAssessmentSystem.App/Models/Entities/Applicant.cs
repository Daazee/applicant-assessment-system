using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicantAssessmentSystem.App.Models.Entities
{
    public class Applicant
    {
        public int ApplicantId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string HighestQualification { get; set; }

        public string InstitutionName { get; set; }

        public int GraduationYear { get; set; }

        public int TotalYearsofExperience { get; set; }

        public string LastorCurrentEmployerName { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public DateTime EmploymentEndDate { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
