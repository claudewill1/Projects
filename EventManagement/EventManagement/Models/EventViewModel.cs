using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models
{
    
    public class ViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Location> Locations { get; set; }
    }
}
