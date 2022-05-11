using ApplicantAssessmentSystem.App.Context;
using ApplicantAssessmentSystem.App.Models.Entities;
using ApplicantAssessmentSystem.App.Models.ViewModels;
using ApplicantAssessmentSystem.App.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicantAssessmentSystem.App.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly ApplicantAssessmentContext _applicantAssessmentContext;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        public QuestionController(ApplicantAssessmentContext applicantAssessmentContext,IQuestionRepository questionRepository, IMapper mapper)
        {
            _applicantAssessmentContext = applicantAssessmentContext;
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        [Route("GetQuestionBySubjectAndNumber")]
        public async Task<IActionResult> GetQuestionBySubjectAndNumber(string subject, int number)
        {
            var question = await _questionRepository.GetQuestionBySubjectAndNumber(subject, number);
            var questionDTO = _mapper.Map<Question, QuestionViewModel>(question);
            return Ok(questionDTO);
        }

        [Route("GetQuestionBySubject")]
        public async Task<IActionResult> GetQuestionBySubject(string subject, int number)
        {
            var questions = await _questionRepository.GetQuestionBySubject(subject);
            var questionsDTO = _mapper.Map<List<Question>, List<QuestionViewModel>>(questions);
            return Ok(questionsDTO);
        }
    }
}
