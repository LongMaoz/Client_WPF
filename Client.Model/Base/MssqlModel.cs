using Client.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model.Base
{
    [SqlTypeAttribute(SqlTypeEnum.Mssql)]
    public class MssqlModel:BaseModel
    {
    }
}
