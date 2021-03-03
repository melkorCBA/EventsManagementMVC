﻿using System.ComponentModel.DataAnnotations;

namespace EventsManagementSolution.Models
{
    public class User
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Password { get; set; }



    }
}