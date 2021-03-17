using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManagement.Models;

namespace EventManagement.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Event Event { get; set; }
        public string PageTitle { get; set; }
    }
}
