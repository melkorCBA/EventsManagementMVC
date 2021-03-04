using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EventsManagementSolution.Models
{
    public class LoginResponse
    {

        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public LoginDTO LoginDTO { get; set; }
    }

    public class LoginDTO
    {
        [DisplayName("LoggedUserID")]
        public int LoggedUserID { get; set; }

        public string ResponseMessage { get; set; }

        // 1 for success 0 for failier
        public int Status { get; set; }
    }
}