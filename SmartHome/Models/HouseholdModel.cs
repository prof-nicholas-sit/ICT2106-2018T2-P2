using System;

namespace SmartHome.Models
{
    public class HouseholdModel:User
    {
        public int houseHoldID { get; set; }
        public string street { get; set; }
        public int postalCode { get; set; }
        public string unitNo { get; set; }
        public string surname { get; set; }
        public string contactNo { get; set; }
        public Boolean isLogin { get; set; }
    }
}