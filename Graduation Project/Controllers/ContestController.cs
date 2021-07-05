﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GraduationProject.Data.Models;
using GraduationProject.Data.Repositories.Interfaces;
using GraduationProject.Data.Repositories.IProblemRepository;
using GraduationProject.ViewModels.ContestViewsModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers.Contest
{
    public class ContestController : Controller
    {
        readonly private IContestRepository<GraduationProject.Data.Models.Contest> contests;
        readonly private IProblemRepository<Problem> problems; 
        readonly private User user; 
        public ContestController(IContestRepository<GraduationProject.Data.Models.Contest> contests
            , IUserRepository<User> Userrepository
            , IHttpContextAccessor httpContextAccessor
            , IProblemRepository<Problem> problems)
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            user = Userrepository.Find(userId);
            this.contests = contests;
            this.problems = problems; 
        }
        // GET: HomeController
        public ActionResult Index()
        {
            var list = contests.PublicContests(); 
            return View(list);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int Id)
        {
            var contest = contests.Find(Id);
            var model = getContestViewModelFromContest(contest); 
            return View(model);
        }

        // GET: HomeController/Create
        public ActionResult Create(int Id)
        {
            ViewBag.ID = Id; 
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GraduationProject.Data.Models.Contest contest)
        {
            try
            {
                Boolean PublicContest = (contest.groupId == 0 ? true : false);
                contest.InGroup = !PublicContest;  
                if (PublicContest)
                    contest.groupId = null;
                contests.CreateNewContest(user.UserId, contest); 
                if (PublicContest)
                    return RedirectToAction("Index");
                else 
                    return RedirectToAction("Details", "Group", new { id = contest.groupId });
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            var contest = contests.Find(id); 
            return View(contest);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GraduationProject.Data.Models.Contest contest)
        {
            try
            {
                contests.Update(contest);
                if (contest.groupId != null)
                    return RedirectToAction("Details", "Group", new { id = contest.groupId });
                else
                    return RedirectToAction("Index"); 
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            var contest = contests.Find(id);
            return View(contest);
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(GraduationProject.Data.Models.Contest contest)
        {
            try
            {
                int? groupId = contests.Find(contest.contestId).groupId; 
                contests.Remove(contest.contestId);
                if (groupId != null)
                    return RedirectToAction("Details", "Group", new { id = groupId });
                else
                    return RedirectToAction("Index"); 
            }
            catch
            {
                return View();
            }
        }
        public ActionResult RegisterInContest(int id)
        {
            contests.RegisterInContest(user.UserId, id);
            return RedirectToAction("Details", new { id });
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProblemToContest(int contestId, string problemName)
        {
            var problem = problems.FindByName("CodeForces", problemName); 
            if (problem == null)
                return RedirectToAction("Details", new { id = contestId });
            try
            {
                contests.AddProblemToContest(problem.ProblemId, contestId); 
                return RedirectToAction("Details", new { id = contestId });
            }
            catch
            {
                return RedirectToAction("Details", new { id = contestId });
            }
        }
        private ViewContestModel getContestViewModelFromContest(Data.Models.Contest contest)
        {
            string contestStatus = "";
            switch (contest.contestStatus)
            {
                case -1:
                    contestStatus = "Upcoming";
                    break;
                case 0:
                    contestStatus = "Running";
                    break;
                case 1:
                    contestStatus = "Ended";
                    break;
            }
            ICollection<Problem> Problems = new HashSet<Problem>();
            foreach (var item in contest.ContestProblems.ToList())
                Problems.Add(item.problem);
            return new ViewContestModel 
            { 
                contestId = contest.contestId, 
                contestDuration = contest.contestDuration, 
                contestStartTime = contest.contestStartTime, 
                contestStatus = contestStatus, 
                contestTitle = contest.contestTitle, 
                contestVisabilty = contest.contestVisabilty, 
                UserContest = contest.UserContest, 
                creationTime = contest.creationTime, 
                groupId = contest.groupId, 
                Problems = Problems, 
                Submissions = contest.Submissions.ToList()
            };
        }
    }
}
