using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Service.Interface
{
    public interface ITestService
    {
        public Task<string?> GetData();
    }
}
