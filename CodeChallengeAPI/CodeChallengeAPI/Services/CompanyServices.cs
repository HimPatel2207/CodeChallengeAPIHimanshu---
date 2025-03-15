using CodeChallengeAPI.Models;
using CodeChallengeAPI.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CodeChallengeAPI.Services
{
    public class CompanyServices : ICompanyServices
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyServices(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        async Task<List<CompanyModel>> ICompanyServices.GetCompanies(GetList getList)
        {
            var companyList =  _companyRepository.GetCompaniesList(getList).Result;
            return companyList.ToList();
        }

        public CompanyModel GetCompanyById(int id)
        {
            var company = _companyRepository.GetCompanyById(id).Result;
            return company;
        }

        public CompanyModel GetCompanyByISIn(string IsIn)
        {
            var company = _companyRepository.GetCompanyByIsIn(IsIn).Result;
            return company;
        }

        public CompanyModel UpdateCompany(CompanyModel company)
        {
            var companyModel = _companyRepository.UpdateCompany(company).Result;
            return companyModel;
        }

        public CompanyModel DeleteCompany(int id)
        {
            var companyModel = _companyRepository.DeleteCompany(id).Result;
            return companyModel;
        }

        public CompanyModel AddCompany(CompanyModel company)
        {
            var companyModel = _companyRepository.AddCompany(company).Result;
            return companyModel;
        }
    }
}
