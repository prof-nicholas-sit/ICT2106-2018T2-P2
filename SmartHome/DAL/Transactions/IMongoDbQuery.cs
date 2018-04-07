namespace SmartHome.DAL.Transactions
{
    /**
     * Interface for a mongodb query
     */
    public interface IMongoDbQuery
    {
        // execute the query
        void Execute();
        // undo the query (rollback)
        void Undo();
        // for displaying in string format
        string ToString();
    }
}