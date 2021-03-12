using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;
using ServerApp.Models.BindingTargets;

namespace ServerApp.Controllers
{
    [ApiController]
    [Route("api/environments")]
    public class EnvironmentValuesController : Controller
    {
        public DataContext _context;
        public EnvironmentValuesController(DataContext ctx)
        {
            _context = ctx;
        }

        [HttpGet("{id}")]
        public Models.Environment GetEnvironment(long id)
        {
            Models.Environment env = _context.Environments.Include(e => e.Company).ThenInclude(e => e.Industry).Include(e => e.EnvironmentType).Include(e => e.DatabaseDependency).Include(e => e.ApiDependency).Include(e => e.LastHealthCheck).Include(e => e.Product).Include(e => e.Server).ThenInclude(e => e.ServerType).Include(e => e.Server).ThenInclude(e => e.operatingSystem).Include(e => e.WebServer).FirstOrDefault(e => e.EnvironmentId == id);
            return env;
        }

        [HttpGet]
        public IEnumerable<Models.Environment> GetEnvironments(string environmentType, string company, string product, string search, bool related = false , bool metatdata = false)
        {
            IQueryable<Models.Environment> query = _context.Environments.Include( env => env.Company).Include( env => env.EnvironmentType ).Include( env => env.Product );
            if (!String.IsNullOrWhiteSpace(environmentType))
            {
                string environmentTypeLower = environmentType.ToLower();
                query = query.Where(envs => envs.EnvironmentType.Name.ToLower().Contains(environmentTypeLower)).Include(env => env.Company).Include(env => env.EnvironmentType).Include(env => env.LastHealthCheck).Include(env => env.Product).Include(env => env.Server).ThenInclude(e => e.ServerType).Include(e => e.Server).ThenInclude(e => e.operatingSystem).Include(env => env.WebServer).OrderBy(e => e.Product).OrderBy(e => e.Company).OrderBy(e => e.EnvironmentType.EnvironmentTypeId);
            }
            if (!String.IsNullOrWhiteSpace(company))
            {
                string companyLower = company.ToLower();
                query = query.Where(envs => envs.Company.Name.ToLower().Contains(companyLower)).Include(env => env.Company).Include(env => env.EnvironmentType).Include(env => env.LastHealthCheck).Include(env => env.Product).Include(env => env.Server).ThenInclude(e => e.ServerType).Include(e => e.Server).ThenInclude(e => e.operatingSystem).Include(env => env.WebServer).OrderBy(e => e.Product).OrderBy(e => e.Company).OrderBy(e => e.EnvironmentType.EnvironmentTypeId);
            }
            if (!String.IsNullOrWhiteSpace(product))
            {
                string productLower = product.ToLower();
                query = query.Where(envs => envs.Product.Name.ToLower().Contains(productLower)).Include(env => env.Company).Include(env => env.EnvironmentType).Include(env => env.LastHealthCheck).Include(env => env.Product).Include(env => env.Server).ThenInclude(e => e.ServerType).Include(e => e.Server).ThenInclude(e => e.operatingSystem).Include(env => env.WebServer).OrderBy(e => e.Product).OrderBy(e => e.Company).OrderBy(e => e.EnvironmentType.EnvironmentTypeId);
            }

            if (!String.IsNullOrWhiteSpace(search))
            {
                string searchLower = search.ToLower();
                query = query.Where(
                    envs => envs.Product.Name.ToLower().Contains(searchLower)
                            || envs.ApplicationHyperLink.ToLower().Contains(searchLower)
                            || envs.Company.Name.ToLower().Contains(searchLower)
                            || envs.Company.Industry.Name.ToLower().Contains(searchLower)
                            || envs.Company.Industry.Description.ToLower().Contains(searchLower)
                            || envs.Company.Ntn.ToLower().Contains(searchLower)
                            || envs.Company.OperationalPoc.FirstName.ToLower().Contains(searchLower)
                            || envs.Company.OperationalPoc.MiddleName.ToLower().Contains(searchLower)
                            || envs.Company.OperationalPoc.LastName.ToLower().Contains(searchLower)
                            || envs.Company.OperationalPoc.Email.ToLower().Contains(searchLower)
                            || envs.Company.OperationalPoc.LoginName.ToLower().Contains(searchLower)
                            || envs.Company.OperationalPoc.Mobile.ToLower().Contains(searchLower)
                            || envs.Company.OperationalPoc.PhoneExtension.ToString().ToLower().Contains(searchLower)
                            || envs.Company.TechnicalPoc.FirstName.ToLower().Contains(searchLower)
                            || envs.Company.TechnicalPoc.MiddleName.ToLower().Contains(searchLower)
                            || envs.Company.TechnicalPoc.LastName.ToLower().Contains(searchLower)
                            || envs.Company.TechnicalPoc.Email.ToLower().Contains(searchLower)
                            || envs.Company.TechnicalPoc.LoginName.ToLower().Contains(searchLower)
                            || envs.Company.TechnicalPoc.Mobile.ToLower().Contains(searchLower)
                            || envs.Company.TechnicalPoc.PhoneExtension.ToString().ToLower().Contains(searchLower)
                            || envs.Company.ProjectPoc.FirstName.ToLower().Contains(searchLower)
                            || envs.Company.ProjectPoc.MiddleName.ToLower().Contains(searchLower)
                            || envs.Company.ProjectPoc.LastName.ToLower().Contains(searchLower)
                            || envs.Company.ProjectPoc.Email.ToLower().Contains(searchLower)
                            || envs.Company.ProjectPoc.LoginName.ToLower().Contains(searchLower)
                            || envs.Company.ProjectPoc.Mobile.ToLower().Contains(searchLower)
                            || envs.Company.ProjectPoc.PhoneExtension.ToString().ToLower().Contains(searchLower)
                            || envs.Company.FinancialPoc.FirstName.ToLower().Contains(searchLower)
                            || envs.Company.FinancialPoc.MiddleName.ToLower().Contains(searchLower)
                            || envs.Company.FinancialPoc.LastName.ToLower().Contains(searchLower)
                            || envs.Company.FinancialPoc.Email.ToLower().Contains(searchLower)
                            || envs.Company.FinancialPoc.LoginName.ToLower().Contains(searchLower)
                            || envs.Company.FinancialPoc.Mobile.ToLower().Contains(searchLower)
                            || envs.Company.FinancialPoc.PhoneExtension.ToString().ToLower().Contains(searchLower)
                            || envs.Company.Comments.ToLower().Contains(searchLower)
                            || envs.Company.Email.ToLower().Contains(searchLower)
                            || envs.Company.Fax.ToLower().Contains(searchLower)
                            || envs.Company.Phone.ToLower().Contains(searchLower)
                            || envs.Company.TagLine.ToLower().Contains(searchLower)
                            || envs.Company.Website.ToLower().Contains(searchLower)
                            || envs.Dependency.ToLower().Contains(searchLower)
                            || envs.Description.ToLower().Contains(searchLower)
                            || envs.DockerDescription.ToLower().Contains(searchLower)
                            || envs.DockerImage.ToLower().Contains(searchLower)
                            || envs.EnvironmentType.Name.ToLower().Contains(searchLower)
                            || envs.EnvironmentType.Description.ToLower().Contains(searchLower)
                            || envs.LastHealthCheck.Description.ToLower().Contains(searchLower)
                            || envs.LastHealthCheck.Directory.ToLower().Contains(searchLower)
                            || envs.LastHealthCheck.ReferenceLink.ToLower().Contains(searchLower)
                            || envs.ModifiedDate.ToString().ToLower().Contains(searchLower)
                            || envs.WebServer.Name.ToLower().Contains(searchLower)
                            || envs.WebServer.Description.ToLower().Contains(searchLower)
                            || envs.Product.Category.ToLower().Contains(searchLower)
                            || envs.Product.Description.ToLower().Contains(searchLower)
                            || envs.Product.masterReleaseLink.ToLower().Contains(searchLower)
                            || envs.Product.masterReleaseWorkingDirecotory.ToLower().Contains(searchLower)
                            || envs.Product.ReleaseNotes.ToLower().Contains(searchLower)
                            || envs.Product.Supplier.Name.ToLower().Contains(searchLower)
                            || envs.Product.Supplier.Email.ToLower().Contains(searchLower)
                            || envs.Product.Supplier.Phone.ToLower().Contains(searchLower)
                            || envs.Product.Supplier.Website.ToLower().Contains(searchLower)
                            || envs.Product.Type.Name.ToLower().Contains(searchLower)
                            || envs.Product.Type.Description.ToLower().Contains(searchLower)
                            || envs.Remarks.ToLower().Contains(searchLower)
                            || envs.Server.Description.ToLower().Contains(searchLower)
                            || envs.Server.Domain.ToLower().Contains(searchLower)
                            || envs.Server.Ip.ToLower().Contains(searchLower)
                            || envs.Server.Name.ToLower().Contains(searchLower)
                            || envs.Title.ToLower().Contains(searchLower)
                            || envs.WorkingDirectory.ToLower().Contains(searchLower)
                    );
            }

            if (related)
            {
                query = query.Include(env => env.Company).Include(env => env.EnvironmentType).Include(env => env.LastHealthCheck).Include(env => env.Product).Include(env => env.Server).ThenInclude(e => e.ServerType).Include(e => e.Server).ThenInclude(e => e.operatingSystem).Include(env => env.WebServer).OrderBy(e => e.Product).OrderBy(e => e.Company).OrderBy(e => e.EnvironmentType.EnvironmentTypeId);
                List<Models.Environment> data = query.ToList();
                data.ForEach(e => {
                    if (e.ApiDependency != null)
                    {
                        e.ApiDependency.ForEach(apis => apis.Environment = null);
                    }
                    if (e.DatabaseDependency != null)
                    {
                        //e.DatabaseDependency.ForEach(ev => ev.);
                    }
                });

                return data;
                //return metatdata ? CreateMetadata(data) : Ok(data);
            }
            else
            {
                return query;
                //return metatdata ? CreateMetadata(query) : Ok(query);
            }
        }

        public IActionResult CreateMetadata(IEnumerable<Models.Environment> environments)
        {
            return Ok(new
            {
                data = environments,
                environmentTypes = _context.Environments.Select(env => env.EnvironmentType).Distinct().OrderBy( e => e),
                companies = _context.Environments.Select(env => env.Company).Distinct().OrderBy(e => e),
                products = _context.Environments.Select(env => env.Product).Distinct().OrderBy(e => e)
            }); 
        }

        [HttpPost]
        public ActionResult AddEnvironment([FromBody] EnvironmentData eData )
        {
            if (ModelState.IsValid)
            {
                Models.Environment environment = eData.Environment;
                if(environment.ApiDependency.Count > 0)
                {
                    foreach (Api i in environment.ApiDependency)
                    {
                        if (i != null && i.ApiId != 0)
                        {
                            _context.Attach(i);
                        }
                    }
                }
                if(environment.Company != null && environment.Company.CompanyId != 0)
                {
                    _context.Attach(environment.Company);
                }
                if(environment.DatabaseDependency.Count > 0)
                {
                    foreach (Database i in environment.DatabaseDependency)
                    {
                        if (i != null && i.DatabaseId != 0)
                        {
                            _context.Attach(i);
                        }
                    }
                }
                if(environment.EnvironmentType != null && environment.EnvironmentType.EnvironmentTypeId != 0)
                {
                    _context.Attach(environment.EnvironmentType);
                }
                if(environment.LastHealthCheck != null && environment.LastHealthCheck.HealthCheckId != 0)
                {
                    _context.Attach(environment.LastHealthCheck);
                }
                if(environment.Product != null && environment.Product.ProductId != 0)
                {
                    _context.Attach(environment.Product);
                }
                if(environment.Server != null && environment.Server.ServerId != 0)
                {
                    _context.Attach(environment.Server);
                }
                if(environment.WebServer != null && environment.WebServer.WebServerId != 0)
                {
                    _context.Attach(environment.WebServer);
                }
                _context.Add(environment);
                _context.SaveChanges();
                return Ok(environment.EnvironmentId);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEnvironment(long id ,[FromBody] EnvironmentData eData)
        {
            if (ModelState.IsValid)
            {
                Models.Environment environment = eData.Environment;
                environment.EnvironmentId = id;
                if (environment.ApiDependency.Count > 0)
                {
                    foreach (Api i in environment.ApiDependency)
                    {
                        if (i != null && i.ApiId != 0)
                        {
                            _context.Attach(i);
                        }
                    }
                }
                if (environment.Company != null && environment.Company.CompanyId != 0)
                {
                    _context.Attach(environment.Company);
                }
                if (environment.DatabaseDependency.Count > 0)
                {
                    foreach (Database i in environment.DatabaseDependency)
                    {
                        if (i != null && i.DatabaseId != 0)
                        {
                            _context.Attach(i);
                        }
                    }
                }
                if (environment.EnvironmentType != null && environment.EnvironmentType.EnvironmentTypeId != 0)
                {
                    _context.Attach(environment.EnvironmentType);
                }
                if (environment.LastHealthCheck != null && environment.LastHealthCheck.HealthCheckId != 0)
                {
                    _context.Attach(environment.LastHealthCheck);
                }
                if (environment.Product != null && environment.Product.ProductId != 0)
                {
                    _context.Attach(environment.Product);
                }
                if (environment.Server != null && environment.Server.ServerId != 0)
                {
                    _context.Attach(environment.Server);
                }
                if (environment.WebServer != null && environment.WebServer.WebServerId != 0)
                {
                    _context.Attach(environment.WebServer);
                }
                _context.Update(environment);
                _context.SaveChanges();
                return Ok(environment.EnvironmentId);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEnvironment(long id)
        {
            Models.Environment environment = _context.Environments.Find(id);
            if (environment != null && environment.EnvironmentId != 0)
            {
                _context.Environments.Remove(environment);
                _context.SaveChanges();
                return Ok(environment.EnvironmentId);
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
