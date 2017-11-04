using DBSync.SqlLiteDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBSync.SqlLiteDb
{
    public class SettingsManager
    {
        private static Object syncObj = new Object();

        private Dictionary<String, String> _settings;

        private static SettingsManager _instance;

        private SettingsManager()
        {
            using (SettingsContext context = new SettingsContext())
            {
                context.Database.Initialize(true);
            }                
        }

        private void AddSetting(String name, String value)
        {
            using (SettingsContext context = new SettingsContext())
            {
                context.Set<Setting>().Add(new Setting()
                {
                    SettingName = name,
                    SettingValue = value
                });
                context.SaveChangesAsync();
            }          
        }

        private void SetSettingValue(String name, String value)
        {
            if(_settings.ContainsKey(name))
            {
                _settings[name] = value;
             
                using (SettingsContext context = new SettingsContext())
                {
                    Setting setting = context.Set<Setting>().FirstOrDefault(s => s.SettingName == name);
                    if (setting != null)
                    {
                        setting.SettingValue = value;
                        context.Entry(setting).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChangesAsync();
                        return;
                    }
                }
            }

            AddSetting(name, value);           
        }


        private String GetSettingValue(String name, String defaultValue = "")
        {
            String value;
            if (!_settings.TryGetValue(name, out value))
            {
                AddSetting(name, defaultValue);
                value = defaultValue;
            }

            return value;
        }

        public void LoadSettings()
        {
            using (SettingsContext context = new SettingsContext())
            {               
                _settings = context.Set<Setting>().ToDictionary(s => s.SettingName, s => s.SettingValue);
            }
            
        }
              
        public static SettingsManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncObj)
                    {
                        if (_instance == null)
                        {
                            _instance = new SettingsManager();
                        }
                    }
                }
                return _instance;
            }
        }

        
        #region Settings

        public String Lang
        { 
            get { return GetSettingValue("Lang"); }
            set { SetSettingValue("Lang",value); }
        }

        public Boolean SafeTransaction
        {
            get { return Boolean.Parse(GetSettingValue("safeTran",Boolean.TrueString)); }
            set { SetSettingValue("safeTran", value.ToString()); }
        }

        #endregion

    }
}
