using CompanyRecords.API.Context;
using CompanyRecords.API.Models.Entity;
using CompanyRecords.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyRecords.API.Repositories.Repos
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly AppDbContext _context; // Add a private field for the context

        public CompanyRepository(AppDbContext context) : base(context)
        {
            _context = context; // Initialize the context field
        }

        public async Task<Company?> GetByIsinAsync(string isin)
            => await _context.Companies.FirstOrDefaultAsync(c => c.Isin == isin);

        public async Task<bool> IsIsinExistsAsync(string isin)
            => await _context.Companies.AnyAsync(c => c.Isin == isin);
    }
}
