namespace SmartHome.DAL.Transactions
{
    public interface IMongoDbQuery
    {
        void Execute();
        void Undo();
        string ToString();
    }
}