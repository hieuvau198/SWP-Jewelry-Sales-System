﻿using JewelBO;

namespace JewelService.ServiceGold
{
    public interface IGoldService
    {
        List<Gold> GetGolds();
        Gold GetGold(string goldId);
        Boolean AddGold(Gold gold);
        Boolean RemoveGold(string goldId);
        Boolean UpdateGold(Gold gold);
    }
}
