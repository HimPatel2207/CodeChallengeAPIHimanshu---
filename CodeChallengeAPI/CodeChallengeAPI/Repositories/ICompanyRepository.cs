using CodeChallenge.Repository.CompanyDatabase;
using CodeChallengeAPI.Models;

namespace CodeChallengeAPI.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<CompanyModel>> GetCompaniesList(GetList getList);
        Task<CompanyModel?> GetCompanyById(int id);
        Task<CompanyModel?> GetCompanyByIsIn(string idIsIn);
        Task<CompanyModel> AddCompany(CompanyModel company);
        Task<CompanyModel> UpdateCompany(CompanyModel company);
        Task<CompanyModel> DeleteCompany(int id);
    }
}
