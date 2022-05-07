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
        private readonly IMapper _mapper;
        public ApplicantController(IApplicantRepository applicantRepository, IMapper mapper)
        {
            _applicantRepository = applicantRepository;
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
                    var applicant = _mapper.Map<ApplicantViewModel, Applicant>(viewModel);
                   await _applicantRepository.AddItem(applicant);

                    return RedirectToAction(nameof(Applicants));
                }
            }
            catch(Exception ex)
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
