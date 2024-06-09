using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Tests.Service
{
    public class MyService : IMyService
    {
        public string GetData()
        {
            // Logic để lấy dữ liệu từ nơi nào đó
            return "Real Data";
        }
    }
}
