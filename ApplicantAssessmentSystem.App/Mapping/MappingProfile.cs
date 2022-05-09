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
            // Domain to DTOs or Domain to ViewModel
            CreateMap<Applicant, ApplicantViewModel>();
            CreateMap<Question, QuestionViewModel>();
            CreateMap<ApplicantAnswerDetails, ApplicantAnswerDetailsViewModel>();
            CreateMap<ApplicantAnswerSummary, ApplicantAnswerSummaryViewModel>();
            //.ForMember(dest => dest.StatusDisplay, opt => opt.MapFrom(src => src.Status == 0 ? "Draft" : "Closed"));

            // DTOs to Domain

            CreateMap<ApplicantViewModel, Applicant>();
            CreateMap<QuestionViewModel, Question>();
            CreateMap<ApplicantAnswerDetailsViewModel, ApplicantAnswerDetails>();
            CreateMap<ApplicantAnswerSummaryViewModel, ApplicantAnswerSummary>();
        }
    }
}
