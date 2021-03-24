using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;
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

    }
}
