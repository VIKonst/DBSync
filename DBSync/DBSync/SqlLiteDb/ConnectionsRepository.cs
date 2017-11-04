using DBSync.SqlLiteDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSync.SqlLiteDb
{
    public class ConnectionsRepository : IDisposable
    {
        private static Object syncObj = new Object();
        SettingsContext _context;
        private ConnectionsRepository()
        {
            _context = new SettingsContext();
            _context.Database.Initialize(true);
        }

        private static ConnectionsRepository _instance;
        public static ConnectionsRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncObj)
                    {
                        if (_instance == null)
                        {
                            _instance = new ConnectionsRepository();
                        }
                    }
                }
                return _instance;
            }
        }

        public void AddOrUpdateConnection(Connection connection)
        {
            Connection existsConnection = _context.Set<Connection>().FirstOrDefault(c => c.Server.Equals(connection.Server));
            if (existsConnection == null)
            {
                _context.Set<Connection>().Add(connection);
                _context.SaveChangesAsync();
            }
            else
            {
                existsConnection.Server = connection.Server;
                existsConnection.IsWindowsAuth = connection.IsWindowsAuth;
                existsConnection.UserName = connection.UserName;
                existsConnection.Pass = connection.Pass;
                
                _context.Entry<Connection>(existsConnection).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public List<Connection> GetConnections()
        {
            return _context.Set<Connection>().ToList();
        }

        public List<String> GetServerNames()
        {
            return _context.Set<Connection>().Select(s=>s.Server).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        ~ConnectionsRepository()
        {
            Dispose();
        }
    }
}
