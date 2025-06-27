using CompanyRecords.API.Models.Entity;

namespace CompanyRecords.API.Repositories.Interfaces
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<Company?> GetByIsinAsync(string isin);
        Task<bool> IsIsinExistsAsync(string isin);
    }
}
