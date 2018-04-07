namespace SmartHome.Models
{
    /**
     * Abstract class representing an account, used for Household and Administrator
     */
    public abstract class Account : MongoDbObject
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsLogin { get; set; }
    }
}