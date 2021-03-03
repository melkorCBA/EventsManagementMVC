using System;
using System.ComponentModel.DataAnnotations;

namespace EventsManagementSolution.Models
{
    public class Comment
    {

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public User Author { get; set; }

        public EventModel Event { get; set; }


    }
}