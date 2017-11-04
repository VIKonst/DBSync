using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlScripting;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public class SqlType : SqlObject
    {
        public override SqlObjectType Type
        {
            get
            {
                return SqlObjectType.Type;
            }
        }

        public override String TypeName
        {
            get
            {
                return "Type";
            }
        }

        public override String TypeStatement
        {
            get
            {
                return "T";
            }
        }


        public String SystemTypeName { get; set; }

        public Int16 MaxLength { get; set; }

        public String ColationName { get; set; }

        public Byte Precision { get; set; }

        public Byte Scale { get; set; }
        public Boolean IsNulable { get; set; }

        public String XmlCollectionName { get; set; }

        public List<SqlColumn> Columns { get; set; } = new List<SqlColumn>();

        public String NullStatement 
        {
            get 
            {
                if (IsNulable)
                    return "NULL";
                else 
                    return "NOT NULL";
            }
        }

        public override String CreateScript()
        {
            return $"CREATE TYPE {QualifiedName} FROM {GetTypeStatement()}{SqlStatement.GO}";

        }

        public String GetTypeStatement()
        {
            return $"{GetTypeNameStatement()} {NullStatement}";
        }

        private String GetTypeNameStatement()
        {
            if (SystemTypeName.Equals("decimal") || SystemTypeName.Equals("numeric"))
            {
                return String.Format("{0}({1},{2})", SystemTypeName, Precision, Scale);
            }

            if (SystemTypeName.Equals("time") || SystemTypeName.Equals("datetimeoffset"))
            {
                return String.Format("{0}({1})", SystemTypeName, Scale);
            }

            if (SystemTypeName.Equals("varchar") || SystemTypeName.Equals("char") ||
                SystemTypeName.Equals("varbinary") || SystemTypeName.Equals("binary"))
            {
                if (MaxLength < 0)
                {
                    return String.Format("{0}(max)", SystemTypeName);
                }
                else
                {
                    return String.Format("{0}({1})", SystemTypeName, MaxLength);
                }
            }

            if (SystemTypeName.Equals("nvarchar") || SystemTypeName.Equals("nchar"))
            {
                if (MaxLength < 0)
                {
                    return String.Format("{0}(max)", SystemTypeName);
                }
                else
                {
                    return String.Format("{0}({1})", SystemTypeName, MaxLength / 2);
                }
            }

            if (SystemTypeName.Equals("xml"))
            {
                return "xml";
                /*if (this.IsXmlDocument)
                {
                    return String.Format("xml (DOCUMENT [{0}].[{1}])", XmlCollectionSchemaName, XmlCollectionName);
                }
                else
                {
                    return String.Format("xml (CONTENT [{0}].[{1}])", XmlCollectionSchemaName, XmlCollectionName);
                }*/
            }


            return $"[{SystemTypeName}]";
        }

        public override String DropScript()
        {
            return $"DROP TYPE {QualifiedName}{SqlStatement.GO}";
        }
    }
}
