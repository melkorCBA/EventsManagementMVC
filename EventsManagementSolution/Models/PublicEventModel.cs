using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EventsManagementSolution.Models
{
    public class PublicEventModel
    {
        
        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        
        public DateTime EndDate { get; set; }

        public double? Duration { get; set; }

        public string Description { get; set; }

        public string Place { get; set; }

        [DisplayName("PublisherId")]
        public int PublisherId { get; set; }

        [DisplayName("FullName")]
        public string PublisherName { get; set; }


    }
}