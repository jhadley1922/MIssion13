using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MIssion13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MIssion13.Controllers
{
    public class HomeController : Controller
    {
        private BowlersDbContext _context { get; set; }

        public HomeController(BowlersDbContext temp)
        {
            _context = temp;
        }

        // Home page with contact info table
        public IActionResult Index()
        {
            // Get list of bowlers from the db
            var bowlers = _context.Bowlers.ToList();

            return View(bowlers);
        }

        // Display page with form to add a new bowler
        [HttpGet]
        public IActionResult NewBowler()
        {
            ViewBag.Teams = _context.Teams.ToList();

            return View();
        }

        // Submit form to add the new bowler
        [HttpPost]
        public IActionResult NewBowler(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _context.Add(b);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else // if invalid
            {
                ViewBag.Teams = _context.Teams.ToList();

                return View();
            }
        }

        // Display form with selecter bowler's info to edit
        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Teams = _context.Teams.ToList();

            // Get bowler data
            var bowler = _context.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View("NewBowler", bowler);
        }

        // Save edits to the db
        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _context.Update(b);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else // if invalid
            {
                ViewBag.Teams = _context.Teams.ToList();

                return View("NewBowler", b);
            }

        }

        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var movie = _context.Bowlers.Single(x => x.BowlerID == bowlerid);

            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            _context.Bowlers.Remove(b);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
