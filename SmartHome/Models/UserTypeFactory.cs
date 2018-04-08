using System;
using SmartHome.DAL.Mappers;

namespace SmartHome.Models
{
    public class UserTypeFactory
    {

        public static IUser CreateUser(String username, String password)
        {
            char firstChar = username[0];
            if (Char.IsLetter(firstChar))
            {
                return new AdminMapper().Login(username, password); //AdminModel(user.Username,user.password);
            }
            else if(Char.IsDigit(firstChar))

            {
                return new HouseholdMapper().Login(username,password);//HouseholdModel(user.Username,user.password);
            }
            else
            {
                return null;
            }

        }

        public static void CreateHousehold(String username,String password,string email,string street,int postalCode,string unitNo,string surname,string contactNo )
        {
            Household newHousehold =
                new Household(username, password, email, street, postalCode, unitNo, surname, contactNo);
            new HouseholdMapper().Create(newHousehold).Save().Commit();
            
                //null; //new HouseholdModel(user.getUsername(),user.getPassword(),user.getEmail(),householdId,street,postalCode,unitNo,surname,contactNo);

        }
        
        
    }
}