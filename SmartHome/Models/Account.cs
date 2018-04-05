namespace SmartHome.Models
{
    public abstract class Account : MongoDbObject,IUser
    {
        public Account() : base()
        {
            
        }
        public Account(string Username, string Password,string Email):base()
        {
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            this.IsLogin = false;

        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsLogin { get; set; }
    }
}