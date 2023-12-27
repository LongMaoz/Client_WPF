using Client.Model.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class SqlTypeAttribute:Attribute
    {
        public SqlTypeAttribute(SqlTypeEnum sqltype)
        {
            this.SqlType = sqltype;
        }
        public SqlTypeEnum SqlType { get; }
    }
}
