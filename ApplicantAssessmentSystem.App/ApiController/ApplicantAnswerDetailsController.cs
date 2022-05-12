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
    public class ApplicantAnswerDetailsController : ControllerBase
    {
        private readonly ApplicantAssessmentContext _applicantAssessmentContext;
        private readonly IApplicantAnswerDetailsRepository _applicantAnswerDetailsRepository;
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly IApplicantAnswerSummaryRepository _applicantAnswerSummaryRepository;
        private readonly ITransferRepository _transferRepository;
        public ApplicantAnswerDetailsController(ApplicantAssessmentContext applicantAssessmentContext, IApplicantAnswerDetailsRepository applicantAnswerDetailsRepository, IQuestionRepository questionRepository,
                                                IApplicantAnswerSummaryRepository applicantAnswerSummaryRepository, ITransferRepository transferRepository, IMapper mapper)
        {
            _applicantAssessmentContext = applicantAssessmentContext;
            _applicantAnswerDetailsRepository = applicantAnswerDetailsRepository;
            _questionRepository = questionRepository;
            _applicantAnswerSummaryRepository = applicantAnswerSummaryRepository;
            _transferRepository = transferRepository;
            _mapper = mapper;
        }

        [Route("saveAnswers")]
        [HttpPost]
        public async Task<IActionResult> saveAnswers(List<ApplicantAnswerDetailsViewModel> answerDetailsViewModels)
        {
            try
            {
                //calculate answer on submission
                int subjectTotalScore = 0;
                int subjectTotalObatinable = 0;


                foreach (var answer in answerDetailsViewModels)
                {
                    ApplicantAnswerDetails question = _mapper.Map<ApplicantAnswerDetailsViewModel, ApplicantAnswerDetails>(answer);
                    await _applicantAnswerDetailsRepository.AddItem(question);



                    //Get question detail
                    var questionDetail = await _questionRepository.GetQuestionBySubjectAndNumber(answer.Subject, answer.QuestionNumber);
                    if (questionDetail != null)
                    {
                        subjectTotalObatinable += questionDetail.AttributedScore;
                        if (questionDetail.Answer == answer.SelectedAnswer)
                        {
                            subjectTotalScore += questionDetail.AttributedScore;
                        }
                        else
                        {
                            subjectTotalScore += 0;
                        }
                    }
                }

                ApplicantAnswerSummary applicantAnswerSummary = new ApplicantAnswerSummary();
                applicantAnswerSummary.ApplicantId = answerDetailsViewModels.First().ApplicantId;
                applicantAnswerSummary.ApplicantScore = subjectTotalScore;
                applicantAnswerSummary.SessionId = 0;
                applicantAnswerSummary.TotalObtainable = subjectTotalObatinable;
                applicantAnswerSummary.Subject = answerDetailsViewModels.First().Subject;
                await _applicantAnswerSummaryRepository.AddItem(applicantAnswerSummary);

                if (answerDetailsViewModels.First().IsLastSubject == true)//calculate average to move to pass student
                {
                    var summaryScore = await _applicantAnswerSummaryRepository.GetTestScoreByApplicantId(answerDetailsViewModels.First().ApplicantId);
                    if (summaryScore.Count() > 0)
                    {

                        double totalApplicantScore = 0;
                        double totalObatinableScore = 0;


                        foreach (var summary in summaryScore)
                        {
                            totalApplicantScore += summary.ApplicantScore;
                            totalObatinableScore += summary.TotalObtainable;
                        }

                        //calculate percentage
                        double applicantScorePercentage = totalApplicantScore / totalObatinableScore * 100;

                        if (applicantScorePercentage > 50.0)
                        {
                            Transfer transfer = new Transfer();
                            transfer.ApplicantId = answerDetailsViewModels.First().ApplicantId;
                            await _transferRepository.AddItem(transfer);
                            return Ok("pass");
                        }
                        else
                            return Ok("fail");
                    }
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
