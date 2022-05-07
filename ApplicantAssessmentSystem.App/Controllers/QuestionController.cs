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
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
      
        public QuestionController(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }
        // GET: QuestionController
        public async Task<ActionResult> Index()
        {
            var questions = await _questionRepository.GetItems();
            var applicantsViewModel = _mapper.Map<List<Question>, List<QuestionViewModel>>(questions.ToList());
            return View(applicantsViewModel);
        }

        // GET: QuestionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuestionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(QuestionViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var question = _mapper.Map<QuestionViewModel, Question>(viewModel);
                    await _questionRepository.AddItem(question);
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: QuestionController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var question = await _questionRepository.GetItem(id);
            var questionViewModel = _mapper.Map<Question, QuestionViewModel>(question);
            return View(questionViewModel);
        }

        // POST: QuestionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, QuestionViewModel viewModel)
        {
            try
            {
                var question = _mapper.Map<QuestionViewModel, Question>(viewModel);
                await _questionRepository.UpdateItem(question);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuestionController/Delete/5
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
