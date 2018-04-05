﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SmartHome.Models
{
    public class Household : Account
    {
        public Household():base()
        {
            
        }
        public Household(string Username, string Password,string Email,string Street,int PostalCode,string UnitNo,string Surname,string ContactNo) : base(Username,Password,Email)
        {
            this.Street = Street;
            this.PostalCode = PostalCode;
            this.UnitNo = UnitNo;
            this.Surname = Surname;
            this.ContactNo = ContactNo;
            IsResetPassword = false;

        }
        public ObjectId houseHoldId { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
        public string UnitNo { get; set; }
        public string Surname { get; set; }
        public string ContactNo { get; set; }
        public bool IsResetPassword { get; set; }
    }
}
