using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventsManagementSolution.Models
{
    public class EventModel
    {
        [Required]
        public int EventId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public double? Duration { get; set; }

        public string Description { get; set; }

        public string Place { get; set; }

        public Boolean? Visibility { get; set; }

        public User Publisher { get; set; }

        public ICollection<Comment> Comments { get; set; }


    }
}