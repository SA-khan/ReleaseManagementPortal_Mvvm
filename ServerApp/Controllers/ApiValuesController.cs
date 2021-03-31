using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;
using ServerApp.Models.BindingTargets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Controllers
{
    [Route("api/apis")]
    [ApiController]
    public class ApiValuesController : Controller
    {
        public DataContext _context;
        public ApiValuesController(DataContext ctx)
        {
            _context = ctx;
        }

        [HttpGet("{id}")]
        public IActionResult GetApi(long id)
        {
            Models.Api api = _context.Apis.Include(a => a.Environment).ThenInclude(a => a.DatabaseDependency).FirstOrDefault(a => a.ApiId == id);
            return Ok(api);
        }
        [HttpGet]
        public IActionResult GetApis()
        {
            IEnumerable<Models.Api> apis = _context.Apis.Include(a => a.Environment).ThenInclude(a => a.DatabaseDependency);
            foreach(Api item in apis)
            {
                if(item.Environment != null)
                {
                    item.Environment.ApiDependency = null;
                }
            }
            return Ok(apis);
        }

        [HttpPatch]
        public IActionResult UpdateApi(long id, [FromBody] JsonPatchDocument<ApiData> patch)
        {
            Api api = _context.Apis.FirstOrDefault(a => a.ApiId == id);
            List<string> dbnames = new List<string>();
            List<string> dbinstances = new List<string>();
            List<Server> dbservers = new List<Server>();
            List<string> dbserverip = new List<string>();
            List<string> dbserveruserid = new List<string>();
            List<string> dbserverpassword = new List<string>();
            List<Database> dbs = api.Databases;
            foreach(var item in dbs)
            {
                dbnames.Add(item.Name);
                dbinstances.Add(item.Instance);
                dbservers.Add(item.Server);
            }
            foreach(var item in dbservers)
            {
                dbserverip.Add(item.Ip);
                dbserveruserid.Add(item.UserId);
                dbserverpassword.Add(item.Password);
            }
            ApiData data = new ApiData { Api = api };
            patch.ApplyTo(data, ModelState);
            if(ModelState.IsValid && TryValidateModel(patch))
            {
                if(api.Environment != null && api.Environment.EnvironmentId != 0)
                {
                    _context.Attach(api.Environment);
                }
                if (api.Product != null && api.Product.ProductId != 0)
                {
                    _context.Attach(api.Product);
                }
                foreach(Database database in api.Databases)
                {
                    if(database != null && database.DatabaseId != 0)
                    {
                        _context.Attach(database);
                    }
                }
                foreach (Api apii in api.Apis)
                {
                    if (apii != null && apii.ApiId != 0)
                    {
                        _context.Attach(apii);
                    }
                }
                _context.SaveChanges();



                return Ok(id);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
