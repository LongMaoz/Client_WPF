using Client.Model;
using Client.Model.Base;
using Client.Model.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Client.Data
{
    public class DbContextInfoMssql : DbContext
    {
        public string conntionStr;

        /// <summary>
        /// 重写动态注册实体方法
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //加载model程序集
            var ass = Assembly.Load("Client.Model");
            //获取所有的标记TableAttribute,SqlTypeAttribute不为空 的实体类 并且数据库连接为mssql
            var assList = ass.GetExportedTypes()
                .Where(x => !string.IsNullOrEmpty(x.GetCustomAttribute<TableAttribute>()?.Name) 
                && x.IsSubclassOf(typeof(MssqlModel))).ToList();

            //循环插入实体类类型
            foreach (var type in assList)
            {
                if (type.BaseType == typeof(object))
                    modelBuilder.Model.AddEntityType(type);
            }

            //循环插入数据表模型
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = modelBuilder.Entity(entity.Name).Metadata.GetTableName();
                modelBuilder.Entity(entity.Name).ToTable(tableName);
            }

        }

        /// <summary>
        /// 拦截configuration，重新装载sql链接字符串
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conntionStr);
        }
    }
}
