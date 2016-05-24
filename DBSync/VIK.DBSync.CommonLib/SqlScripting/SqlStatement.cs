using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.SqlScripting
{
    public static class SqlStatement
    {
        public static readonly String GO = Environment.NewLine+"GO"+Environment.NewLine;

        public const String IF = "IF";
        public const String ON = "ON";
        public const String OFF = "OFF";
        public const String CREATE = "CREATE ";
        public const String NULL = "NULL";
        public const String NOT_NULL = "NOT NULL";
        public const String ALTER_TABLE = "ALTER TABLE";


        private const String ANSI_NULL_FORMAT = "SET ANSI_NULLS {0}";
        private const String QUOTED_IDENTIFIER_FORMAT = "SET QUOTED_IDENTIFIER {0}";

        public const String CHECK_ERROR = "IF @@ERROR<> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END";
        public const String COMMIT = "IF @@TRANCOUNT>0 COMMIT";
        public static String GetOnOffStatement(Boolean isOn)
        {
            return isOn ? ON : OFF;
        }

        public static String GetAnsiNullsStatemt(Boolean isOn)
        {   
            return String.Format(ANSI_NULL_FORMAT, isOn ? ON : OFF);
        }

        public static String GetQuotedIdentifierStatemt(Boolean isOn)
        {
            return String.Format(QUOTED_IDENTIFIER_FORMAT, isOn ? ON : OFF);
        }

        public static String GetCreateStatemt(String name)
        {
            return String.Concat(CREATE, name);
        }

        public static String GetAlterTableStatemt(String name)
        {
            return String.Concat(ALTER_TABLE," ", name);
        }
    }
}
