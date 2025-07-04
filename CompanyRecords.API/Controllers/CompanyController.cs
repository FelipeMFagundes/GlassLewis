﻿using AutoMapper;
using CompanyRecords.API.Models.DTO;
using CompanyRecords.API.Models.Entity;
using CompanyRecords.API.Repositories.Interfaces;
using CompanyRecords.API.Repositories.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace CompanyRecords.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CompanyDto dto)
        {
            if (!Regex.IsMatch(dto.Isin, "^[A-Z]{2}\\d{10}$"))
                return BadRequest("ISIN must start with 2 letters and be 12 characters.");

            if (await _companyRepository.IsIsinExistsAsync(dto.Isin))
                return Conflict("ISIN already exists.");

            var c = _mapper.Map<Company>(dto);

            await _companyRepository.AddAsync(c);
            await _companyRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = c.Id }, c);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Company>> GetById(int id)
            => await _companyRepository.GetByIdAsync(id) is Company c ? Ok(c) : NotFound();

        [HttpGet("isin/{isin}")]
        public async Task<ActionResult<Company>> GetByIsin(string isin)
            => await _companyRepository.GetByIsinAsync(isin) is Company c ? Ok(c) : NotFound();

        [HttpGet]
        public async Task<IEnumerable<Company>> GetAll() => await _companyRepository.GetAllAsync();

        [HttpPut()]
        public async Task<IActionResult> Update(CompanyDto dto)
        {
            var c = await _companyRepository.GetByIdAsync(dto.Id);
            if (c is null) return NotFound();

            if (c.Isin != dto.Isin && await _companyRepository.IsIsinExistsAsync(dto.Isin))
                return Conflict("ISIN already exists.");

            c = _mapper.Map<Company>(dto);
            await _companyRepository.UpdateAsync(c);
            return NoContent();
        }
    }
}
