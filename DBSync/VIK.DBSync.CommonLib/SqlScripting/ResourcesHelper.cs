using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.SqlScripting
{
    public class ResourcesHelper
    {
        public static String GetScriptFromResources(String name)
        {           
            Stream stream = Assembly.GetAssembly(typeof(ResourcesHelper)).GetManifestResourceStream(name);
            StreamReader reader = new StreamReader(stream);
            String result = reader.ReadToEnd();
            reader.Close();
            return result;
        }
    }
}
