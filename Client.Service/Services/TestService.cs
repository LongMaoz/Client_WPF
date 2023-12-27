using System;
using System.Linq;
using System.Threading.Tasks;
using Client.Data;
using Client.Model.Base;
using Client.Model.Model.SqlLite;
using Client.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Client.Service.Services;

public class TestService : ITestService
{
    private DbContextInfoSqlLite _dbContext;
    public TestService(DbContextInfoSqlLite dbcontext)
    {
        _dbContext = dbcontext;
        try
        {
            _dbContext.Database.EnsureCreated();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred when connecting to the database: {ex.Message}");
        }
    }
    public IQueryable<T> GetIQueryable<T>() where T : SqlLiteModel
    {
        return _dbContext.Set<T>().AsQueryable();
    }

}