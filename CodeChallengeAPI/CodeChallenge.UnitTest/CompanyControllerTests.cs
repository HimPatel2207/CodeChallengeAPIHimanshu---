using CodeChallengeAPI.Controllers;
using CodeChallengeAPI.Models;
using CodeChallengeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CodeChallengeAPI.Tests
{
    public class CompanyControllerTests
    {
        private readonly Mock<ICompanyServices> _companyServicesMock;
        private readonly Mock<ILogger<CompanyController>> _loggerMock;
        private readonly CompanyController _controller;

        public CompanyControllerTests()
        {
            _companyServicesMock = new Mock<ICompanyServices>();
            _loggerMock = new Mock<ILogger<CompanyController>>();
            _controller = new CompanyController(_loggerMock.Object, _companyServicesMock.Object);
        }

        [Fact]
        public async Task GetAllCompaniesList_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var getList = new GetList { PageNo = 1, Record = 10, SortBy = "Name", SortType = "asc" };
            var companies = new List<CompanyModel> { new CompanyModel { Id = 1, Name = "Company1" } };
            _companyServicesMock.Setup(service => service.GetCompanies(getList)).ReturnsAsync(companies);

            // Act
            var result = await _controller.GetAllCompaniesList(getList);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<CompanyModel>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task GetCompanyById_ValidId_ReturnsOkResult()
        {
            // Arrange
            var company = new CompanyModel { Id = 1, Name = "Company1" };
            _companyServicesMock.Setup(service => service.GetCompanyById(1)).Returns(company);

            // Act
            var result = await _controller.GetCompanyById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CompanyModel>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task GetCompanyById_InvalidId_ReturnsBadRequest()
        {
            // Act
            var result = await _controller.GetCompanyById(0);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task AddNewCompany_ValidCompany_ReturnsOkResult()
        {
            // Arrange
            var company = new CompanyModel { Id = 1, Name = "Company1" };
            _companyServicesMock.Setup(service => service.AddCompany(company)).Returns(company);

            // Act
            var result = await _controller.AddNewCompany(company);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CompanyModel>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task UpdateCompany_ValidCompany_ReturnsOkResult()
        {
            // Arrange
            var company = new CompanyModel { Id = 1, Name = "Company1" };
            _companyServicesMock.Setup(service => service.UpdateCompany(company)).Returns(company);

            // Act
            var result = await _controller.UpdateCompany(company);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CompanyModel>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task DeleteCompany_ValidId_ReturnsOkResult()
        {
            // Arrange
            var company = new CompanyModel { Id = 1, Name = "Company1" };
            _companyServicesMock.Setup(service => service.DeleteCompany(1)).Returns(company);

            // Act
            var result = await _controller.DeleteCompany(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CompanyModel>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }
    }
}
