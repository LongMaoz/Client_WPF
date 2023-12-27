using Client.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model.Model.SqlLite
{
    [Table("Product")]
    public class ProductModel:SqlLiteModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
