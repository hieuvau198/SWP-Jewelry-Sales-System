using JewelBO;

namespace JewelService.SeviceStall
{
    public interface IStallService
    {
        List<Stall> GetStalls();
        Stall GetStall(string stallId);
        Stall AddStall(Stall stall);
        bool UpdateStall(Stall stall);
        bool RemoveStall(string stallId);

    }
}
