using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Summitworks_EventManager.Models;

namespace Summitworks_EventManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventSchedule _eventSchedule;

        public HomeController(IEventSchedule eventSchedule)
        {
            _eventSchedule = eventSchedule;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
