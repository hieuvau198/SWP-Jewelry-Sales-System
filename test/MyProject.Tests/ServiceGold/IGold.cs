using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Tests.ServiceGold
{
    public interface IGoldService
    {
        bool AddGold(Gold gold);
        List<Gold> GetGolds();
        Gold GetGold(string goldId);
        bool RemoveGold(string goldId);
        bool UpdateGold(Gold gold);
    }

}
