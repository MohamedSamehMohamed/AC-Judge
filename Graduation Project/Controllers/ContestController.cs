﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GraduationProject.Data.Models;
using GraduationProject.Data.Repositories.Interfaces;
using GraduationProject.ViewModels.ContestViewsModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers.Contest
{
    public class ContestController : Controller
    {
        readonly private IRepository<GraduationProject.Data.Models.Contest> contests;
        readonly private User user; 
        public ContestController(IRepository<GraduationProject.Data.Models.Contest> contests, IUserRepository<User> Userrepository, IHttpContextAccessor httpContextAccessor)
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            user = Userrepository.Find(userId);
            this.contests = contests; 
        }
        // GET: HomeController
        public ActionResult Index()
        {
            var list = contests.List(); 
            return View(list);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int Id)
        {
            var contest = contests.Find(Id);
            var model = getContestViewModelFromContest(contest); 
            return View(model);
        }

        private ViewContestModel getContestViewModelFromContest(Data.Models.Contest contest)
        {
            string contestStatus = "";
            switch(contest.contestStatus)
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
            foreach (var item in contest.ContestProblems.Where(c => c.contestId == contest.contestId).ToList())
                Problems.Add(item.problem); 
            return new ViewContestModel { contestId = contest.contestId, contestDuration = contest.contestDuration, contestStartTime = contest.contestStartTime, contestStatus = contestStatus, contestTitle = contest.contestTitle, contestVisabilty = contest.contestVisabilty, UserContest = contest.UserContest, creationTime = contest.creationTime, groupId = contest.groupId, Problems = Problems, Submissions = contest.Submissions.Where(c=>c.contestId == contest.contestId).ToList(), group = contest.group};
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
                contest.creationTime = DateTime.Now; 
                contests.Add(contest);
                var userContest = new UserContest { UserId = user.UserId, ContestId = contest.contestId, isFavourite = false, isOwner = true, isRegistered = true };
                contest.UserContest.Add(userContest);
                contests.Update(contest); 
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

            return View();
        }

        // POST: HomeController/Edit/5
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

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
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
