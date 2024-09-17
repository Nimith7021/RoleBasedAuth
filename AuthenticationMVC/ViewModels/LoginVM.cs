using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthenticationMVC.Models;

namespace AuthenticationMVC.ViewModels
{
    public class LoginVM
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}