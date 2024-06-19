using JewelBO;

namespace JewelDAO.DAOStall
{
    public interface IStallDao
    {
        List<Stall> GetStalls();
        Stall GetStall(string stallId);
        Stall AddStall(Stall stall);
        Boolean RemoveStall(string stallId);
        Boolean UpdateStall(Stall stall);
    }
}
