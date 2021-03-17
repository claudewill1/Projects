using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Summitworks_EventManager.Models
{
    public class Event
    {
        [Key]
        public int ID { get; set; }
        [Required]
        
        public string EventName { get; set; }
        [Required]
        public Category? EventCategory { get; set; }
        [Required]
        
        public string Organizer { get; set; }
        [Required]
        
        public string Address { get; set; }

        [Required]
        
        public string City { get; set; }
        [Required]
        
        public string State { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public string EventDescription { get; set; }
        [Required]
        public DateTime EventDateTime { get; set; }
        //[Required]
        //public DateTime EventTime { get; set; }
        [Required]
        public string EventStatus { get; set; }
        

        //internal Event GetEvent(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //internal Event GetEvent(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
