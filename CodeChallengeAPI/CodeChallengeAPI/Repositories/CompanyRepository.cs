using CodeChallenge.Repository.CompanyDatabase;
using CodeChallengeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeChallengeAPI.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CodeChallengeGlasslewisContext _context;
        public CompanyRepository(CodeChallengeGlasslewisContext DBContext)
        {
            _context = DBContext;
        }

        public async Task<CompanyModel> AddCompany(CompanyModel company)
        {
            await _context.CompanyModel.AddAsync(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<IEnumerable<CompanyModel>> GetCompaniesList(GetList getList)
        {
            return await _context.CompanyModel
                .OrderBy(b => b.Id)
                .Skip((getList.PageNo - 1) * getList.Record)
                .Take(getList.Record).AsQueryable().ToListAsync();
        }

        public async Task<CompanyModel?> GetCompanyById(int id)
        {
            return await _context.CompanyModel.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CompanyModel?> GetCompanyByIsIn(string idIsIn)
        {
            return await _context.CompanyModel.AsQueryable().FirstOrDefaultAsync(x => x.Isin == idIsIn);
        }
        public async Task<CompanyModel> UpdateCompany(CompanyModel company)
        {
            _context.CompanyModel.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }
        public async Task<CompanyModel> DeleteCompany(int id)
        {
            _context.CompanyModel.Remove(_context.CompanyModel.Find(id));
            await _context.SaveChangesAsync();
            return _context.CompanyModel.Find(id);
        }


    }
}
