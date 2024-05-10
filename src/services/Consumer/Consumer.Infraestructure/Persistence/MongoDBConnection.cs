using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Consumer.Infraestructure.Persistence
{
    public class MongoDBConnection : IDisposable
    {
        private bool disposed = false;
        private static MongoClient client = null!;
        private static readonly object _lock = new();

        public static MongoClient GetClient(IConfiguration configuration)
        {
            if (client != null)
            {
                return client;
            }

            lock (_lock)
            {
                if(client == null)
                {
                    var connString = configuration.GetSection("MongoDBSettings")["ConnectionString"];
                    client = new MongoClient(connString);
                }
            }

            return client;
        }

        public virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                if (disposing) { }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
