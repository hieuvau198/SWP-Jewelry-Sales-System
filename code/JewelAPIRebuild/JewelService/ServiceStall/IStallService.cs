

using JewelBO;

namespace JewelService.ServiceStall
{
    public interface IStallService
    {
        List<Stall> GetStalls();
        Stall GetStall(string stallId);
        Stall AddStall(Stall stall);
        Boolean RemoveStall(string stallId);
        Boolean UpdateStall(Stall stall);
    }
}
