using ApplicantAssessmentSystem.App.Models.Entities;
using ApplicantAssessmentSystem.App.Models.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicantAssessmentSystem.App.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to DTOs
            CreateMap<Applicant, ApplicantViewModel>();
            CreateMap<Question, QuestionViewModel>();
            //.ForMember(dest => dest.StatusDisplay, opt => opt.MapFrom(src => src.Status == 0 ? "Draft" : "Closed"));

            // DTOs to Domain

            CreateMap<ApplicantViewModel, Applicant>();
            CreateMap<QuestionViewModel, Question>();
        }
    }
}
