using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MIssion13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIssion13.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private BowlersDbContext _context { get; set; }

        public TeamsViewComponent(BowlersDbContext temp)
        {
            _context = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamID"];

            // Retrieves the list of teams for the filter
            var teams = _context.Teams.ToList();

            return View(teams);
        }
    }
}
