﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class User
    {
        public int ID { get;set; } 
        public string Email { get;set; } 
        public string Password { get;set; } 
        public int Admin { get;set; }
        public string Salt { get; set; }
        public ICollection<DbLog> DbLogs { get; set; }
        public ICollection<Reminder> Reminders { get; set; }
    }
}