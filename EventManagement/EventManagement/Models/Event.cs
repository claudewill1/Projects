using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models
{

    public class Event
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(30)]
        public string EventName { get; set; }
        [Required]
        public Category? EventCategory { get; set; }
        [Required]
        [MaxLength(30)]
        public string Organizer { get; set; }
        [Required]
        [MaxLength(50)]
        public string AddressLine1 { get; set; }
        [Required]
        [MaxLength(50)]
        public string AddressLine2 { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(20)]
        public string State { get; set; }
        [Required]
        public int ZipCode { get; set; }

        [Required]
        public DateTime EventDateTime { get; set; }
        [Required]
        public string Status { get; set; }

    }
}
