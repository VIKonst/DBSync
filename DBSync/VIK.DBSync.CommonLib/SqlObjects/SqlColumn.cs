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

        public Int32 Precision { get; set; }

        public Int32 Scale { get; set; }

        public Int32 MaxLength { get; set; }

        public Boolean IsNulable { get; set; }

        public Boolean IsIdentity { get; set; }

        public Object IdentitySeed { get; set; }

        public Object IdentityIncrement { get; set; }

        public Boolean IsComputed { get; set; }

        public String ComputedDefinition { get; set; }

        public Boolean IsPersisted { get; set; }

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
                if(!String.IsNullOrEmpty(ColationName) && !IsComputed)   
                {
                    return "COLLATE " + ColationName;
                }   
                return String.Empty;
            }
        }

        public String CreateStatement 
        {
            get 
            {
                return String.Format("[{0}]\t{1} {2} {3} {4}",this.Name, this.TypeStatement,
                this.IdentityStatement, this.ColationStatement, this.NullStatement);
            }
        }

        public Int32 CompareTo(SqlColumn other)
        {
            Int32 result = this.Name.CompareTo(other.Name);
            if(result != 0) return result;

            result = this.CreateStatement.CompareTo(other.CreateStatement);
            
            return result;
        }
    }
}
