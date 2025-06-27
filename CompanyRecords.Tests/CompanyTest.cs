using CompanyRecords.API.Context;
using CompanyRecords.API.Controllers;
using CompanyRecords.API.Mapper;
using CompanyRecords.API.Models.DTO;
using CompanyRecords.API.Models.Entity;
using CompanyRecords.API.Repositories.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRecords.Tests
{
    [TestClass]
    public sealed class CompanyTest
    {
        private readonly AppDbContext _context;
        public CompanyTest()
        {
            _context = ContextGenerator.Generate(); // Initialize the context using the generator
        }
        [TestMethod]
        public async Task TestCreateCompanyAsync()
        {
            // Arrange  
            var rep = new CompanyRepository(_context); // Ensure the repository is initialized with the context
            var comp = new Company
            {
                Isin = "US0378331005", // Example ISIN for Apple Inc.  
                Name = "Apple Inc.2",
                Exchange = "NASDAQ2",
                Ticker = "AAPL",
                WebsiteUrl = "http://www.apple.com"
            };
            
            // Act  
            await rep.AddAsync(comp);
            // Assert  
            Assert.IsTrue(await rep.ExistsAsync(1)); // Verify the company exists
            Assert.AreEqual("US0378331005", (await rep.GetByIdAsync(1)).Isin); // Verify the ISIN matches

        }

        [TestMethod]
        public async Task TestGetCompanyById()
        {
            // Arrange  
            var rep = new CompanyRepository(_context); // Ensure the repository is initialized with the context
            var comp = new Company
            {
                Isin = "US0378331005", // Example ISIN for Apple Inc.  
                Name = "Apple Inc.2",
                Exchange = "NASDAQ2",
                Ticker = "AAPL",
                WebsiteUrl = "http://www.apple.com"
            };
            _context.Companies.Add(comp);
            _context.SaveChanges(); // Save the initial company to the in-memory database
            // Act  
            var result = await rep.GetByIdAsync(1);
            // Assert  
            Assert.IsTrue(rep.ExistsAsync(1).Result); // Corrected: Use the static method directly
            Assert.IsNotNull(result); // Ensure the result is not null 
            Assert.AreEqual("US0378331005", result.Isin); // Verify the ISIN matches
        }
        [TestMethod]
        public async Task TestGetCompanyByIsinAsync()
        {
            // Arrange  
            var rep = new CompanyRepository(_context); // Ensure the repository is initialized with the context
            var comp = new Company
            {

                Isin = "US0378331005", // Example ISIN for Apple Inc.  
                Name = "Apple Inc.2",
                Exchange = "NASDAQ2",
                Ticker = "AAPL",
                WebsiteUrl = "http://www.apple.com"
            };
            _context.Companies.Add(comp);
            _context.SaveChanges(); // Save the initial company to the in-memory database
            // Act  
            var result = await rep.GetByIsinAsync("US0378331005");
            // Assert  
            Assert.IsTrue(await rep.IsIsinExistsAsync("US0378331005"));
            Assert.IsNotNull(result); // Ensure the result is not null
            Assert.AreEqual("US0378331005", result.Isin); // Verify the ISIN matches

        }
        [TestMethod]
        public async Task TestGetAllCompaniesAsync()
        {
            // Arrange   
            var rep = new CompanyRepository(_context); // Ensure the repository is initialized with the context
            var comp = new Company
            {

                Isin = "US0378331005", // Example ISIN for Apple Inc.  
                Name = "Apple Inc.2",
                Exchange = "NASDAQ2",
                Ticker = "AAPL",
                WebsiteUrl = "http://www.apple.com"
            };
            _context.Companies.Add(comp);
            _context.SaveChanges(); // Save the initial company to the in-memory database
            // Act  
            var result = await rep.GetAllAsync();
            // Assert  
            Assert.IsTrue(result.Count() > 0);
            Assert.IsTrue(result.Any(c => c.Isin == "US0378331005")); // Verify the company exists in the result
        }
        [TestMethod]
        public async Task TestUpdateCompanyAsync()
        {
            // Arrange  
            var rep = new CompanyRepository(_context);

            var comp = new Company
            {
                
                Isin = "US0378331005", // Example ISIN for Apple Inc.  
                Name = "Apple Inc.2",
                Exchange = "NASDAQ2",
                Ticker = "AAPL",
                WebsiteUrl = "http://www.apple.com"
            };
            _context.Companies.Add(comp);
            _context.SaveChanges(); // Save the initial company to the in-memory database

            var updateComp = new Company
            {
                Id = 1, // Assuming the ID is 1 for the test
                Isin = "US0378331005", // Example ISIN for Apple Inc.  
                Name = "Apple Inc.",
                Exchange = "NASDAQ",
                Ticker = "AAPL",
                WebsiteUrl = "http://www.apple.com"
            };

            // Act  
            await rep.UpdateAsync(updateComp); // Fix: Remove assignment since UpdateAsync returns void

            // Assert  
            Assert.IsTrue(await rep.ExistsAsync(updateComp.Id)); // Verify the update by checking existence
            Assert.AreEqual("Apple Inc.", (await rep.GetByIdAsync(1)).Name); // Verify the name was updated correctly   
            Assert.IsTrue(await rep.IsIsinExistsAsync("US0378331005")); // Verify the ISIN still exists
        }
    }
}
