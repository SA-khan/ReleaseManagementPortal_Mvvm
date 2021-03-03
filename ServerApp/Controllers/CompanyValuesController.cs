using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;
using ServerApp.Models.BindingTargets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ServerApp.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyValuesController : Controller
    {
        public DataContext _context;

        public CompanyValuesController(DataContext ctx) {
            _context = ctx;
        }

        [HttpGet("{id}")]
        public Company GetCompany(long id)
        {
            Company company = _context.Companies.Include(c => c.Industry).Include(c => c.TechnicalPoc).Include(c => c.OperationalPoc).Include(c => c.OperationalPoc).Include(c => c.FinancialPoc).Include(c => c.ProjectPoc).FirstOrDefault(c => c.CompanyId == id);
            return company;
        }

        [HttpGet]
        public IEnumerable<Company> GetCompanies(string Industry, string Search, bool related = false, bool still = true)
        {

            IQueryable<Company> companies = _context.Companies.Where(c => c.Still == still); 

            if (!String.IsNullOrWhiteSpace(Industry))
            {
                string IndustryLower = Industry.ToLower();
                companies = _context.Companies.Include(c => c.Industry).Include(c => c.Ratings).Include(c => c.TechnicalPoc).Include(c => c.OperationalPoc).Include(c => c.OperationalPoc).Include(c => c.FinancialPoc).Include(c => c.Ratings).Where(c => c.Industry.Name.Contains(IndustryLower));
                if(companies != null)
                {
                    foreach (Company com in companies)
                    {
                        if(com != null)
                        {
                            if(com.Ratings != null)
                            {
                                com.Ratings.ForEach( r => r.Company = null );
                            }
                        }
                    }
                }
            }

            if (!String.IsNullOrWhiteSpace(Search))
            {
                string SearchLower = Search.ToLower();
                companies = _context.Companies.Include(c => c.Industry).Include(c=> c.Ratings).Include(c => c.TechnicalPoc).Include(c => c.OperationalPoc).Include(c => c.OperationalPoc).Include(c => c.FinancialPoc).Include(c => c.Ratings).Where(c => c.Name.Contains(SearchLower) || c.TagLine.Contains(SearchLower) || c.Website.Contains(SearchLower) || c.Phone.Contains(SearchLower) || c.Email.Contains(SearchLower) || c.Fax.Contains(SearchLower) || c.Comments.Contains(SearchLower) || c.Logo.Contains(SearchLower) || c.FinancialPoc.FirstName.Contains(SearchLower) || c.FinancialPoc.MiddleName.Contains(SearchLower) || c.FinancialPoc.LastName.Contains(SearchLower) || c.TechnicalPoc.FirstName.Contains(SearchLower) || c.TechnicalPoc.MiddleName.Contains(SearchLower) || c.TechnicalPoc.LastName.Contains(SearchLower) || c.OperationalPoc.FirstName.Contains(SearchLower) || c.OperationalPoc.MiddleName.Contains(SearchLower) || c.OperationalPoc.LastName.Contains(SearchLower) || c.ProjectPoc.FirstName.Contains(SearchLower) || c.ProjectPoc.MiddleName.Contains(SearchLower) || c.ProjectPoc.LastName.Contains(SearchLower) );
                if (companies != null)
                {
                    foreach (Company com in companies)
                    {
                        if (com != null)
                        {
                            if (com.Ratings != null)
                            {
                                com.Ratings.ForEach(r => r.Company = null);
                            }
                        }
                    }
                }
            }

            
            if (related)
            {
                companies = _context.Companies.Include(c => c.Industry).Include(c => c.TechnicalPoc).ThenInclude(c => c.Language).Include(c => c.TechnicalPoc).ThenInclude(c => c.PasswordPolicy).Include(c => c.TechnicalPoc).ThenInclude(c => c.Question1).Include(c => c.TechnicalPoc).ThenInclude(c => c.Question1).Include(c => c.TechnicalPoc).ThenInclude(c => c.Question1).Include(c => c.TechnicalPoc).ThenInclude(c => c.Region).Include(c => c.TechnicalPoc).ThenInclude(c => c.Theme).Include(c => c.OperationalPoc).ThenInclude(c => c.Language).Include(c => c.OperationalPoc).ThenInclude(c => c.PasswordPolicy).Include(c => c.OperationalPoc).ThenInclude(c => c.Question1).Include(c => c.OperationalPoc).ThenInclude(c => c.Question2).Include(c => c.OperationalPoc).ThenInclude(c => c.Question3).Include(c => c.OperationalPoc).ThenInclude(c => c.Region).Include(c => c.OperationalPoc).ThenInclude(c => c.Theme).Include(c => c.ProjectPoc).ThenInclude(c => c.Language).Include(c => c.ProjectPoc).ThenInclude(c => c.PasswordPolicy).Include(c => c.ProjectPoc).ThenInclude(c => c.Question1).Include(c => c.ProjectPoc).ThenInclude(c => c.Question2).Include(c => c.ProjectPoc).ThenInclude(c => c.Question3).Include(c => c.ProjectPoc).ThenInclude(c => c.Region).Include(c => c.ProjectPoc).ThenInclude(c => c.Theme).Include(c => c.FinancialPoc).ThenInclude(c => c.Language).Include(c => c.FinancialPoc).ThenInclude(c => c.PasswordPolicy).Include(c => c.FinancialPoc).ThenInclude(c => c.Question1).Include(c => c.FinancialPoc).ThenInclude(c => c.Question2).Include(c => c.FinancialPoc).ThenInclude(c => c.Question3).Include(c => c.FinancialPoc).ThenInclude(c => c.Region).Include(c => c.FinancialPoc).ThenInclude(c => c.Theme);
                List<Company> data = companies.ToList();
                return data;
            }
            else
            {
                return companies;
            }
            
        }

        [HttpPost]
        public IActionResult AddCompany([FromBody] CompanyData cdata )
        {
            if (ModelState.IsValid)
            {
                Company c = cdata.Company;
                if(c.Industry != null && c.Industry.IndustryId != 0)
                {
                    _context.Attach(c.Industry);
                }
                if (c.TechnicalPoc != null && c.TechnicalPoc.UserId != 0)
                {
                    _context.Attach(c.TechnicalPoc);
                }
                if (c.OperationalPoc != null && c.OperationalPoc.UserId != 0)
                {
                    _context.Attach(c.OperationalPoc);
                }
                if (c.ProjectPoc != null && c.ProjectPoc.UserId != 0)
                {
                    _context.Attach(c.ProjectPoc);
                }
                if (c.FinancialPoc != null && c.FinancialPoc.UserId != 0)
                {
                    _context.Attach(c.FinancialPoc);
                }
                _context.Add(c);
                _context.SaveChanges();
                return Ok(c.CompanyId);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult ReplaceCompany(long id, [FromBody] CompanyData cdata)
        {
            if (ModelState.IsValid)
            {
                Company c = cdata.Company;
                c.CompanyId = id;
                if (c.Industry != null && c.Industry.IndustryId != 0)
                {
                    _context.Attach(c.Industry);
                }
                if (c.TechnicalPoc != null && c.TechnicalPoc.UserId != 0)
                {
                    _context.Attach(c.TechnicalPoc);
                }
                if (c.OperationalPoc != null && c.OperationalPoc.UserId != 0)
                {
                    _context.Attach(c.OperationalPoc);
                }
                if (c.ProjectPoc != null && c.ProjectPoc.UserId != 0)
                {
                    _context.Attach(c.ProjectPoc);
                }
                if (c.FinancialPoc != null && c.FinancialPoc.UserId != 0)
                {
                    _context.Attach(c.FinancialPoc);
                }
                _context.Update(c);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateCompany(long id, [FromBody] JsonPatchDocument<CompanyData> patch)
        {
            Company company = _context.Companies.Include(c => c.Industry).Include(c => c.Ratings).Include(c => c.TechnicalPoc).Include(c => c.OperationalPoc).Include(c => c.OperationalPoc).Include(c => c.FinancialPoc).First(c => c.CompanyId == id);
            CompanyData cdata = new CompanyData { Company = company };
            patch.ApplyTo(cdata, ModelState);
            if (ModelState.IsValid && TryValidateModel(cdata))
            {
                if(company.FinancialPoc != null && company.FinancialPoc.UserId != 0)
                {
                    _context.Attach(company.FinancialPoc);
                }
                if (company.Industry != null && company.Industry.IndustryId != 0)
                {
                    _context.Attach(company.Industry);
                }
                if (company.OperationalPoc != null && company.OperationalPoc.UserId != 0)
                {
                    _context.Attach(company.OperationalPoc);
                }
                if (company.ProjectPoc != null && company.ProjectPoc.UserId != 0)
                {
                    _context.Attach(company.ProjectPoc);
                }
                if (company.TechnicalPoc != null && company.TechnicalPoc.UserId != 0)
                {
                    _context.Attach(company.TechnicalPoc);
                }
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public void RemoveCompany(long id)
        {
            _context.Companies.Remove(new Company { CompanyId = id });
            _context.SaveChanges();
        }


    }
}
