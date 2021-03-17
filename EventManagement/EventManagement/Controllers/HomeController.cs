using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EventManagement.Models;
using System.Dynamic;
using EventManagement.ViewModels;

namespace EventManagement.Controllers
{
    public class HomeController : Controller
    {
        private IEventSchedule _eventSchedule;
        private readonly ILogger<HomeController> logger;

        public HomeController(IEventSchedule eventSchedule,ILogger<HomeController> logger)
        {
            _eventSchedule = eventSchedule;
           this.logger = logger;
        }

        public ViewResult Index()
        {
            var model = _eventSchedule.GetAllEvents();
            return View(model);

        }
        public ViewResult Details(int id)
        {
            Event anEvent = _eventSchedule.GetEvent(id);

            if(anEvent == null)
            {
                Response.StatusCode = 404;
                return View("EventNotFound", id);
            }
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Event = anEvent,
                PageTitle = "Event Details"
            };
            return View(homeDetailsViewModel);
        }

          
    }
}
