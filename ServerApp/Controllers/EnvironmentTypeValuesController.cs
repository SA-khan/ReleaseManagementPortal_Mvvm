using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;
using ServerApp.Models.BindingTargets;

namespace ServerApp.Controllers
{
    [Route("api/environmenttype")]
    [ApiController]
    public class EnvironmentTypeValuesController : Controller
    {
        public DataContext _context;

        public EnvironmentTypeValuesController(DataContext ctx)
        {
            _context = ctx;
        }

        [HttpGet("{id}")]
        public EnvironmentType GetEnvironmentType(long id)
        {
            return _context.EnvironmentTypes.Find(id);
        }

        [HttpGet]
        public IEnumerable<EnvironmentType> GetEnvironmentTypes()
        {
            return _context.EnvironmentTypes;
        }

        [HttpPost]
        public ActionResult AddEnvironmentType([FromBody] EnvironmentType envTypeData)
        {
            if (ModelState.IsValid)
            {
                EnvironmentType envType = envTypeData;
                _context.EnvironmentTypes.Add(envType);
                _context.SaveChanges();
                return Ok(envType.EnvironmentTypeId);
            }
            else
            {
                return BadRequest(envTypeData.EnvironmentTypeId);
            }
        }

    }
}
