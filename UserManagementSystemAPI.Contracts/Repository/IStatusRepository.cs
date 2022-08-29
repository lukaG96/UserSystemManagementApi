using UserManagementSystemAPI.DataLayer.Models;

namespace UserManagementSystemAPI.Contracts.Repository
{
    public interface IStatusRepository : IGenericRepository<Status>
    {
        Task<bool> StatusExist(string code);
        Task<IEnumerable<Status>> GetStatuses();
    }
}
