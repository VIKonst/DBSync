﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlScripting;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public class SubObjectsCollection<T>
        : List<T> where T : SqlSubObject
    {
        public String CreateAllScript()
        {
            StringBuilder script = new StringBuilder();
            foreach (T constraint in this)
            {
                script.AppendLine(constraint.CreateScript());
                script.AppendLine(SqlStatement.GO);
                script.AppendLine();
            }
            return script.ToString();
        }

        public String DropAllScript()
        {
            StringBuilder script = new StringBuilder();
            foreach (T constraint in this)
            {
                script.AppendLine(constraint.DropScript());
                script.AppendLine(SqlStatement.GO);
                script.AppendLine();
            }
            return script.ToString();
        }
    }
}
