﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationMVC.Models
{
    public class Role
    {
        public virtual int Id { get; set; }

        public virtual string RoleName { get; set; } 

        public virtual User User { get; set; } 

    }
}