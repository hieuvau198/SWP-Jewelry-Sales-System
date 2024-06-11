using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Tests.ServiceGem
{
    public interface IGemService
    {
        bool AddGem(Gem gem);
        List<Gem> GetGems();
        Gem GetGem(string gemId);
        bool RemoveGem(string gemId);
        bool UpdateGem(Gem gem);
    }

}
