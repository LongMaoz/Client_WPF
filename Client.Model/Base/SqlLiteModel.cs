using Client.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model.Base
{
    [SqlTypeAttribute(SqlTypeEnum.SqlLite)]
    public class SqlLiteModel:BaseModel
    {

    }
}
