using System.Configuration;
using MongoDB.Driver;

namespace MongocinAPI.App_Start
{
    public class MongoDBContext
    {
        private IMongoDatabase _database;
        private MongoClient _client;

        public IMongoDatabase Database
        {
            get { return _database; }
            internal set { _database = value; }
        }

        public MongoClient Client
        {
            get { return _client; }
            internal set { _client = value; }
        }
        public MongoDBContext()
        {
            _client = new MongoClient(ConfigurationManager.AppSettings["MongoDBHost"]);
            Database = Client.GetDatabase(ConfigurationManager.AppSettings["MongoDBName"]);
        }

    }
}