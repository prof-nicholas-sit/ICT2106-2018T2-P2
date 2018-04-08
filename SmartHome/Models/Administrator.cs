﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    /**
     * Domain Model for Administrator
     */
	public class Administrator : Account
    {
        public Administrator(string Username, string Password, string Email) : base(Username, Password, Email)
        {
            
        }

        public Administrator() : base()
        {
            
        }
    }
}
