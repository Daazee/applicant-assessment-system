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

namespace ApplicantAssessmentSystem.App.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IApplicantAnswerSummaryRepository _applicantAnswerSummaryRepository;
        private readonly IApplicantAnswerDetailsRepository _applicantAnswerDetailsRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        public ApplicantController(IApplicantRepository applicantRepository, IApplicantAnswerSummaryRepository applicantAnswerSummaryRepository,
                                   IApplicantAnswerDetailsRepository applicantAnswerDetailsRepository, IQuestionRepository questionRepository, IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _applicantAnswerSummaryRepository = applicantAnswerSummaryRepository;
            _applicantAnswerDetailsRepository = applicantAnswerDetailsRepository;
            _questionRepository = questionRepository;
            _mapper = mapper;
        }
        public async Task<ActionResult> Applicants()
        {
            var applicants = await _applicantRepository.GetItems();
            var applicantsViewModel = _mapper.Map<List<Applicant>, List<ApplicantViewModel>>(applicants.ToList());
            return View(applicantsViewModel);
        }

        // GET: ApplicantController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApplicantController/Create
        public ActionResult Enrol()
        {
            return View();
        }

        // POST: ApplicantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Enrol(ApplicantViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.Password = Utility.HashPassword(viewModel.Password);
                    var applicant = _mapper.Map<ApplicantViewModel, Applicant>(viewModel);
                    await _applicantRepository.AddItem(applicant);

                    return RedirectToAction(nameof(Applicants));
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

        // GET: ApplicantController/Create
        public ActionResult Test()
        {
            return View();
        }

        // POST: ApplicantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Test(ApplicantViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var applicant = _mapper.Map<ApplicantViewModel, Applicant>(viewModel);
                    await _applicantRepository.AddItem(applicant);

                    return RedirectToAction(nameof(Applicants));
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

        public async Task<ActionResult> MyResult()
        {
            List<ApplicantAnswerSummaryViewModel> applicantScoreSummaryViewModel = new List<ApplicantAnswerSummaryViewModel>();
            int applicantId = Convert.ToInt32(HttpContext.Session.GetString("ApplicantId"));
            string applicantName = HttpContext.Session.GetString("ApplicantName");
            ViewData["ApplicantName"] = applicantName;
            var summaryScore = await _applicantAnswerSummaryRepository.GetTestScoreByApplicantId(applicantId);

            if (summaryScore.Count() > 0)
            {
                applicantScoreSummaryViewModel = _mapper.Map<List<ApplicantAnswerSummary>, List<ApplicantAnswerSummaryViewModel>>(summaryScore);
                return View(applicantScoreSummaryViewModel);
            }


            if (summaryScore.Count() == 0)
            {
                var scoreDetailsQuery = await _applicantAnswerDetailsRepository.GetTestScoreGroupByApplicantId(applicantId);
                if (scoreDetailsQuery.Count() == 0)
                {
                    return View(null);
                }


                foreach (IGrouping<string, ApplicantAnswerDetails> group in scoreDetailsQuery)
                {
                    int subjectTotalScore = 0;
                    int subjectTotalObatinable = 0;
                    foreach (ApplicantAnswerDetails answer in group)
                    {
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
                    applicantAnswerSummary.ApplicantId = applicantId;
                    applicantAnswerSummary.ApplicantScore = subjectTotalScore;
                    applicantAnswerSummary.SessionId = 0;
                    applicantAnswerSummary.TotalObtainable = subjectTotalObatinable;
                    applicantAnswerSummary.Subject = group.Key;
                    await _applicantAnswerSummaryRepository.AddItem(applicantAnswerSummary);
                    applicantScoreSummaryViewModel.Add(_mapper.Map<ApplicantAnswerSummary, ApplicantAnswerSummaryViewModel>(applicantAnswerSummary));
                }

            }
            return View(applicantScoreSummaryViewModel);
        }


        // GET: ApplicantController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApplicantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApplicantController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApplicantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
