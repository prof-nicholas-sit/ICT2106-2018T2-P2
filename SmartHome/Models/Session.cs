using System;
namespace SmartHome.Models
{
    public class Session
    {
        private static Session instance =null;
        private IUser loggedUser;
        private Boolean justLoggedIn = true;

        private Session()
        {
            
        }

        public static Session getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance= new Session();
                    

                }

                return instance;



            }
        }
        


        public void setCurrentUser(IUser user)
        {
            loggedUser =  user;
        }

        public string getCurrentId()
        {
            Account user = (Account) loggedUser;
            return user._id.ToString();

        }

        public bool IsLogin()
        {
            Account user = (Account) loggedUser;
            return user.IsLogin;
        }

        public IUser GetUser()
        {
            Account user = (Account) loggedUser;
            char firstChar = user.Username[0];
            if (Char.IsDigit(firstChar))
            {
                return (Household) loggedUser;
            }
            else
            {
                return (Administrator) loggedUser;
            }
        }

        public void endSession()
        {
            instance = null;
            loggedUser = null;
        }

        public Boolean isFromLogin()
        {
            if (justLoggedIn)
            {
                justLoggedIn = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}