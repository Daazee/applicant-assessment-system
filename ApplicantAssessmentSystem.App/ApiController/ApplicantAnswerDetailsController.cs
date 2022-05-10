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
    public class ApplicantAnswerDetailsController : ControllerBase
    {
        private readonly IApplicantAnswerDetailsRepository _applicantAnswerDetailsRepository;
        private readonly IMapper _mapper;
        public ApplicantAnswerDetailsController(IApplicantAnswerDetailsRepository applicantAnswerDetailsRepository, IMapper mapper)
        {
            _applicantAnswerDetailsRepository = applicantAnswerDetailsRepository;
            _mapper = mapper;
        }

        [Route("saveAnswers")]
        [HttpPost]
        public async Task<IActionResult> saveAnswers(List<ApplicantAnswerDetailsViewModel> answerDetailsViewModels)
        {
            try
            {
                foreach (var answer in answerDetailsViewModels)
                {
                    ApplicantAnswerDetails question = _mapper.Map<ApplicantAnswerDetailsViewModel, ApplicantAnswerDetails>(answer);
                    await _applicantAnswerDetailsRepository.AddItem(question);
                }
                return Ok("success");
            }
            catch (Exception)
            {

                throw;
            }

        }

        [Route("GetAnswerDetailByApplicantId")]
        public async Task<IActionResult> GetAnswerDetailByApplicantId(int applicantId)
        {
            var answers = await _applicantAnswerDetailsRepository.GetTestScoreByApplicantId(applicantId);
            var answersDTO = _mapper.Map<List<ApplicantAnswerDetails>, List<ApplicantAnswerDetailsViewModel>>(answers);
            return Ok(answersDTO);
        }
    }
}
