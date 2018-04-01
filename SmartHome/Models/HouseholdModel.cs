using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class HouseholdModel:User
    {
        public HouseholdModel(String Username,String password) : base(Username,password)
        {
            this.isLogin = false;
        }
        public HouseholdModel(string Username, string password, string email, int houseHoldID,string street,int postalCode,string unitNo,string surname,string contactNo) : base(Username, email, password)
        {
            this.houseHoldID = houseHoldID;
            this.street = street;
            this.postalCode = postalCode;
            this.unitNo = unitNo;
            this.surname = surname;
            this.contactNo = contactNo;
            this.isLogin = false;

        }
        public HouseholdModel() : base()
        {
            this.isLogin = false;
        }        

        
        public int houseHoldID { get; set; }
        public string street { get; set; }
        public int postalCode { get; set; }
        public string unitNo { get; set; }
        public string surname { get; set; }
        public string contactNo { get; set; }
        public Boolean isLogin { get; set; }

    }
}
