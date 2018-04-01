using System;

namespace SmartHome.Models
{
    public class UserTypeFactory
    {

        public static IUser CreateUser(User user)
        {
            char firstChar = user.Username[0];
            if (Char.IsLetter(firstChar))
            {
                return new AdminModel(user.Username,user.password);
            }
            else if(Char.IsDigit(firstChar))

            {
                return new HouseholdModel(user.Username,user.password);
            }
            else
            {
                return null;
            }

        }

        public static IUser CreateHousehold(User user,int householdId,string street,int postalCode,string unitNo,string surname,string contactNo )
        {
            return new HouseholdModel(user.getUsername(),user.getPassword(),user.getEmail(),householdId,street,postalCode,unitNo,surname,contactNo);
            
        }
        
        
    }
}