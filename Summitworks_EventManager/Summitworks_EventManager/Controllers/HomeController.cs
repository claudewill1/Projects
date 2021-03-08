﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Summitworks_EventManager.Models;
using Summitworks_EventManager.ViewModels;

namespace Summitworks_EventManager.Controllers
{
    public class HomeController : Controller
    {
        private IEventSchedule _eventSchedule;

        public HomeController(IEventSchedule eventSchedule)
        {
            _eventSchedule = eventSchedule;
        }
        public ViewResult Index()
        {
            var model = _eventSchedule.GetAllEvents();
            return View(model);
        }
        public ViewResult Details(int id)
        {
            Event anEvent = _eventSchedule.GetEvent(id);

            if (anEvent == null)
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
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Event anEvent)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = _eventSchedule.Add(anEvent);
                return RedirectToAction("details", new { id = newEvent.ID });
            }
            
            return View();
            
        }
    }
}
