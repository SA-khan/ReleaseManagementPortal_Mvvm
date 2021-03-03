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
        public ServerApp.Models.Environment GetEnvironment(long id)
        {
            return _context.Environments.Include(e => e.Company).ThenInclude( e => e.Industry ).Include(e => e.EnvironmentType).Include(e => e.LastHealthCheck).Include(e=>e.OperatingSystem).Include(e=>e.Product).Include(e=>e.Server).ThenInclude( e => e.ServerType ).Include( e => e.WebServer).FirstOrDefault(e => e.EnvironmentId == id);
        }

        [HttpGet]
        public IEnumerable<ServerApp.Models.Environment> GetEnvironments()
        {
            IQueryable<Models.Environment> envs = _context.Environments.Include(env => env.Company).Include(env => env.EnvironmentType).Include(env => env.LastHealthCheck).Include(env => env.OperatingSystem).Include(env => env.Product).Include(env => env.Server).ThenInclude( e => e.ServerType ).Include(env => env.WebServer).OrderBy(e => e.Title);
            return envs;
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
                if(environment.OperatingSystem != null && environment.OperatingSystem.OperatingSystemId != 0)
                {
                    _context.Attach(environment.OperatingSystem);
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
                if (environment.OperatingSystem != null && environment.OperatingSystem.OperatingSystemId != 0)
                {
                    _context.Attach(environment.OperatingSystem);
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
