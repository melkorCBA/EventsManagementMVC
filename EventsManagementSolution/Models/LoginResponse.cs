using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EventsManagementSolution.Models
{
    public class LoginResponse
    {
        [DisplayName("LoggedInUserId")]
        public int LoggedInUserId { get; set; }
    }
}