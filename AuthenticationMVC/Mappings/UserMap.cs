﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthenticationMVC.Models;
using FluentNHibernate.Mapping;

namespace AuthenticationMVC.Mappings
{
    public class UserMap:ClassMap<User>
    {
        public UserMap() {

            Table("Users");
            Id(u => u.Id).GeneratedBy.Identity();
            Map(u => u.UserName);
            Map(u => u.Email);
            Map(u => u.Password);
            HasOne(u => u.Role).PropertyRef(u => u.User).Cascade.All().Constrained();
        }

    }
}