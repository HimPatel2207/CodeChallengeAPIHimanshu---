using CodeChallengeAPI.Models;

namespace CodeChallengeAPI.Services
{
    public interface ICompanyServices
    {
        Task<List<CompanyModel>> GetCompanies(GetList getList);

        CompanyModel GetCompanyById(int id);
        CompanyModel GetCompanyByISIn(string IsIn);

        CompanyModel UpdateCompany(CompanyModel company);
        CompanyModel AddCompany(CompanyModel company);
        CompanyModel DeleteCompany(int id);
    }
}
