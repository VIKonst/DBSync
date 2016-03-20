using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.SqlScripting
{
    public static class SqlStatement
    {
        public const String GO = "GO";
        public const String IF = "IF";
        public const String ON = "ON";
        public const String OFF = "OFF";

        private const String ANSI_NULL_FORMAT = "SET ANSI_NULLS {0}";
        private const String QUOTED_IDENTIFIER_FORMAT = "SET QUOTED_IDENTIFIER {0}";
        public static String GetAnsiNullsStatemt(Boolean isOn)
        {   
            return String.Format(ANSI_NULL_FORMAT, isOn ? ON : OFF);
        }

        public static String GetQuotedIdentifierStatemt(Boolean isOn)
        {
            return String.Format(QUOTED_IDENTIFIER_FORMAT, isOn ? ON : OFF);
        }
    }
}
