using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSync.SqlLiteDb
{
    public class SettingsRepository
    {
        private static string syncObj = "syncObj";
        SettingsContext _context;
        private SettingsRepository()
        {
            _context = new SettingsContext();
            _context.Database.Initialize(true);
        }

        private static SettingsRepository _instance;
        public static SettingsRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncObj)
                    {
                        if (_instance == null)
                        {
                            _instance = new SettingsRepository();
                        }
                    }
                }
                return _instance;
            }
        }

        public void AddConnectionIfNotExist(String serverName)
        {
            int count = _context.Set<Connection>().Count(c => c.Server.Equals(serverName));
            if (count == 0)
            {
                _context.Set<Connection>().Add(new Connection
                {
                    Server = serverName

                });
                _context.SaveChangesAsync();
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
    }
}
