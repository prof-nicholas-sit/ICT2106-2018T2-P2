using System;
using System.Globalization;
using System.IO;
using System.Transactions;
using MongoDB.Bson;

namespace SmartHome.DAL.Transactions
{
    /**
     * Concrete MongoDbQueryDecorator class, logs all query executions to a file named "log.txt"
     */
    public class LoggingMongoDbQuery : MongoDbQueryDecorator
    {
        public LoggingMongoDbQuery(MongoDbQuery mongoDbQuery) : base(mongoDbQuery)
        {
        }

        public override void Execute()
        {
            // format the string, then append the string to log.txt file
            String message = String.Format("{0} ({1}): Execute - {2}",
                DateTime.Now.ToString(CultureInfo.CurrentCulture),
                DecoratedMongoDbQuery.GetType().Name, DecoratedMongoDbQuery.ToString());
            File.AppendAllText(@"log.txt", message + Environment.NewLine);
            Console.WriteLine(message);
            DecoratedMongoDbQuery.Execute();
        }

        public override void Undo()
        {
            // format the string, then append the string to log.txt file
            String message = String.Format("{0} ({1}): Undo - {2}", DateTime.Now.ToString(CultureInfo.CurrentCulture),
                DecoratedMongoDbQuery.GetType().Name, DecoratedMongoDbQuery.ToString());
            File.AppendAllText(@"log.txt", message + Environment.NewLine);
            Console.WriteLine(message);
            DecoratedMongoDbQuery.Undo();
        }

        public override string ToString()
        {
            return DecoratedMongoDbQuery.ToString();
        }
    }
}