using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlScripting;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public class SqlColumn : SqlSubObject, IComparable<SqlColumn>
    {
        public Int32 ColumnId { get; set; }

        public String SytemType { get; set; }
        public String UserType { get; set; }
        public Int32 SytemTypeId { get; set; }
        public Int32 UserTypeId { get; set; }
        public String ColationName { get; set; }

        public Byte Precision { get; set; }

        public Byte Scale { get; set; }

        public Int32 MaxLength { get; set; }

        public Boolean IsNulable { get; set; }

        public Boolean IsIdentity { get; set; }

        public Object IdentitySeed { get; set; }

        public Object IdentityIncrement { get; set; }

        public Boolean IsComputed { get; set; }

        public String ComputedDefinition { get; set; }

        public Boolean IsPersisted { get; set; }

        public Boolean IsRowGuidCol { get; set; }

        public Boolean IsFileStream { get; set; }

        public Boolean IsSparse { get; set; }

        public Boolean IsIdentityNotForReplication  { get; set; }

        public Boolean IsXmlDocument { get; set; }

        public Boolean IsColumnSet { get; set; }

        public String XmlCollectionSchemaName { get; set; }

        public String XmlCollectionName { get; set; }

        public String UserTypeSchemaName { get; set; }

        public Boolean IsUserDefinedType { get; set; }


        public SqlType ColumnType { get; set; }

        public String TypeStatement
        {
            get
            {
                if (IsComputed)
                {
                    String value = String.Format("AS {0} ", ComputedDefinition);
                    if (IsPersisted)
                        value += "PERSISTED";
                    return value;
                }

                if (UserType.Equals("decimal") || UserType.Equals("numeric"))
                {
                    return String.Format("{0}({1},{2})", UserType, Precision, Scale);
                }

                if (UserType.Equals("time") || UserType.Equals("datetimeoffset"))
                {
                    return String.Format("{0}({1})", UserType, Scale);
                }

                if (UserType.Equals("varchar") || UserType.Equals("char") ||
                    UserType.Equals("varbinary") || UserType.Equals("binary"))
                {
                    if (MaxLength < 0)
                    {
                        return String.Format("{0}(max)", UserType);
                    }
                    else
                    {
                        return String.Format("{0}({1})", UserType, MaxLength);
                    }
                }

                if (UserType.Equals("nvarchar") || UserType.Equals("nchar"))
                {
                    if (MaxLength < 0)
                    {
                        return String.Format("{0}(max)", UserType);
                    }
                    else
                    {
                        return String.Format("{0}({1})", UserType, MaxLength / 2);
                    }
                }

                if(UserType.Equals("xml"))
                {
                    if (String.IsNullOrEmpty(XmlCollectionName)) return "xml";
                    if (this.IsXmlDocument)
                    {
                        return String.Format("xml (DOCUMENT [{0}].[{1}])", XmlCollectionSchemaName, XmlCollectionName);
                    }
                    else
                    {
                        return String.Format("xml (CONTENT [{0}].[{1}])", XmlCollectionSchemaName, XmlCollectionName);
                    }
                }

                if(IsUserDefinedType)
                    return  $"[{UserTypeSchemaName}].[{UserType}]";
                else
                    return UserType;
            }
        }

        public String IdentityStatement
        {
            get
            {
                String result = String.Empty;
                if (IsIdentity)
                {
                    result = String.Format("IDENTITY({0},{1})", IdentitySeed, IdentityIncrement);
                    if (IsIdentityNotForReplication) result += " NOT FOR REPLICATION";
                }
                return result;
            }
        }

        public String NullStatement
        {
            get
            {
                if (IsComputed)
                {
                    if (!IsNulable && IsPersisted)
                    {
                        return SqlStatement.NOT_NULL;
                    }
                    else
                    {
                        return String.Empty;                 
                    }
                }

                
                if (IsNulable)
                {
                    return SqlStatement.NULL;
                }
                else
                {
                    return SqlStatement.NOT_NULL;
                }
                
            }
        }

        public String ColationStatement
        {
            get
            {         
                if(!String.IsNullOrEmpty(ColationName) && !IsComputed && !IsUserDefinedType)   
                {
                    return "COLLATE " + ColationName;
                }   
                return String.Empty;
            }
        }

        public Int32 CompareTo(SqlColumn other)
        {
            Int32 result = this.Name.CompareTo(other.Name);
            if(result != 0) return result;

            result = this.CreateScript().CompareTo(other.CreateScript());
            
            return result;
        }

        public override String CreateScript()
        {
            if (this.IsColumnSet) return $"{Name} XML COLUMN_SET FOR ALL_SPARSE_COLUMNS";
            StringBuilder statement = new StringBuilder(String.Empty);
            statement.Append($"[{this.Name}]\t {this.TypeStatement} ");
            if (this.IsFileStream) statement.Append("FILESTREAM ");
            statement.Append($"{this.ColationStatement} {this.NullStatement} ");

            if (this.IsComputed) return statement.ToString();  //Other is not required for computed columns

            if (this.IsSparse) statement.Append("SPARSE ");

            statement.Append(this.IdentityStatement);
            if (this.IsRowGuidCol) statement.Append("ROWGUIDCOL ");

            return statement.ToString();
        }

        public override String DropScript()
        {
            return "";
        }
    }
}
