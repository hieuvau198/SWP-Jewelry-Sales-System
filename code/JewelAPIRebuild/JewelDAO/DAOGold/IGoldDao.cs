﻿using JewelBO;

namespace JewelDAO.DAOGold
{
    public interface IGoldDao
    {
        List<Gold> GetGolds();
        Gold GetGold(string goldId);
        Boolean AddGold(Gold gold);
        Boolean RemoveGold(string goldId);
        Boolean UpdateGold(Gold gold);
    }
}