using JewelBO;
using JewelDAL;
using JewelRepository.RepositoryStall;
using JewelService.SeviceStall;

namespace JewelService.ServiceStall
{
    public class StallService : IStallService
    {
        private readonly IStallRepository _stallRepository;

        public StallService(IStallRepository stallRepository)
        {
            this._stallRepository = stallRepository;
        }

        public Stall AddStall(Stall stall)
        {
            return _stallRepository.AddStall(stall);

        }

        public Stall GetStall(string stallId)
        {
            return _stallRepository.GetStall(stallId);
        }

        public List<Stall> GetStalls()
        {
            return _stallRepository.GetStalls();
        }

        public bool RemoveStall(string stallId)
        {
            return _stallRepository.RemoveStall(stallId);
        }

        public bool UpdateStall(Stall stall)
        {
            return (_stallRepository.UpdateStall(stall));
        }
    }
}
