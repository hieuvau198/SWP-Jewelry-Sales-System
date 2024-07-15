

using JewelBO;

namespace JewelRepository.RepositoryStall
{
    public interface IStallRepository
    {
        List<Stall> GetStalls();
        Stall GetStall(string stallId);
        Stall AddStall(Stall stall);
        Boolean RemoveStall(string stallId);
        Boolean UpdateStall(Stall stall);
    }
}
