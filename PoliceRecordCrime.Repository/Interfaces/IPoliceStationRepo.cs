using PoliceRecordCrime.Models;

namespace PoliceRecordCrime.Repository.Interfaces
{
    public interface IPoliceStationRepo
    {
        Task<IEnumerable<PoliceStation>> GetAll(int page, int pageSize);
        Task<PoliceStation> GetById(int id);
        Task Add(PoliceStation policeStation);
        Task Update(PoliceStation policeStation);
        Task Delete(int id);
        Task <int> Count(int id);
    }
}
