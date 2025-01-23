using LiteDB;

namespace Infrastructure.Context
{
    public class LiteContext : IDisposable
    {
        private readonly LiteDatabase _db;

        public LiteContext(string dataBasePath = "UserDb.db")
        { 
            _db = new LiteDatabase(dataBasePath);
        }

        public ILiteCollection<T> GetCollection<T>(string collectionName)
        {
            return _db.GetCollection<T>(collectionName);
        }

        public void DropCollection(string collectionName)
        {
            _db.DropCollection(collectionName);
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}