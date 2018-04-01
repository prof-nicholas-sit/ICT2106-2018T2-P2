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
    }
}