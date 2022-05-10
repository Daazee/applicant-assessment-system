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
    public class SecurityController : Controller
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;


        public SecurityController(IApplicantRepository applicantRepository, IUserRepository userRepository, IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        //[Route("Security/ManagerLogin")]
        public ActionResult ManagerLogin()
        {
            return View();
        }

        //[Route("Security/ManagerLogin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ManagerLogin(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string username = collection["username"];
                    string password = collection["password"];

                    var result = await _userRepository.GetUserByUsername(username);
                    if (result != null)
                    {
                        if (password == result.Password)
                        {
                            TempData["Username"] = username;
                            TempData["UserId"] = result.UserId;
                            return RedirectToAction("Applicants", "Applicant");
                        }
                        else
                        {
                            ViewData["Message"] = "Invalid username or password";
                        }
                    }
                    else
                    {
                        ViewData["Message"] = "Invalid username or password";
                    }
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        [Route("Security/ApplicantLogin")]
        public ActionResult ApplicantLogin()
        {
            return View();
        }

        [Route("Security/ApplicantLogin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ApplicantLogin(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string username = collection["username"];
                    string password = collection["password"];

                    var result = await _applicantRepository.GetApplicantByUsername(username);
                    if (result != null)
                    {
                        if (password == result.Password)
                        {
                            TempData["Username"] = username;
                            TempData["ApplicantId"] = result.ApplicantId;
                            HttpContext.Session.SetString("ApplicantId", result.ApplicantId.ToString());
                            HttpContext.Session.SetString("ApplicantName", $"{result.FirstName} {result.LastName}");
                            return RedirectToAction("Test", "Applicant");
                        }
                        else
                        {
                            ViewData["Message"] = "Invalid username or password";
                        }
                    }
                    else
                    {
                        ViewData["Message"] = "Invalid username or password";
                    }
                }
            }
            catch(Exception ex)
            {
                return View();
            }
            return View();
        }
    }
}
