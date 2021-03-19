using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;
using ServerApp.Models.BindingTargets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ServerApp.Controllers
{
    [Route("api/databases")]
    [ApiController]
    public class DatabaseValuesController : Controller
    {
        public DataContext _context;
        public DatabaseValuesController(DataContext ctx)
        {
            _context = ctx;
        }
        [HttpGet]
        public IActionResult GetDatabases()
        {
            return Ok(_context.Databases);
        }
        [HttpGet("{id}")]
        public IActionResult GetDatabases(long id)
        {
            Database db = _context.Databases.FirstOrDefault(d => d.DatabaseId == id);
            return Ok(db);
        }
        [HttpPost]
        public IActionResult AddDatabase([FromBody] Database db)
        {
            if (ModelState.IsValid)
            {
                _context.Databases.Add(db);
                _context.SaveChanges();
                return Ok(db.DatabaseId);
            }
            else
            {
                return BadRequest(db);
            }
        }
        [HttpPut]
        public IActionResult ReplaceDatabase([FromBody] Database db)
        {
            if (ModelState.IsValid)
            {
                _context.Databases.Update(db);
                _context.SaveChanges();
                return Ok(db.DatabaseId);
            }
            else
            {
                return BadRequest(db);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateDatabase(long id, [FromBody] JsonPatchDocument<DatabaseData> patch)
        {
            Database database = _context.Databases.Include(d => d.DatabaseVendor).ThenInclude(d => d.Corporation).Include(d => d.BackupTakenPOC).Include(d => d.LdfInformation).Include(d => d.MdfInformation).Include(d => d.Product).Include(d => d.RestoredPOC).Include(d => d.Server).First(p => p.DatabaseId == id);
            string _databaseOldName = database.Name;
            DatabaseData dData = new DatabaseData { Database = database };
            patch.ApplyTo(dData, ModelState);
            if (ModelState.IsValid && TryValidateModel(dData))
            {
                if (database.DatabaseVendor != null && database.DatabaseVendor.DatabaseVendorId != 0)
                {
                    _context.Attach(database.DatabaseVendor);
                }
                if (database.BackupTakenPOC != null && database.BackupTakenPOC.UserId != 0)
                {
                    _context.Attach(database.BackupTakenPOC);
                }
                if (database.Environment != null && database.Environment.EnvironmentId != 0)
                {
                    _context.Attach(database.Environment);
                }
                if (database.LdfInformation != null && database.LdfInformation.DataLogFileId != 0)
                {
                    _context.Attach(database.LdfInformation);
                }
                if (database.MdfInformation != null && database.MdfInformation.DataLogFileId != 0)
                {
                    _context.Attach(database.MdfInformation);
                }
                if (database.Product != null && database.Product.ProductId != 0)
                {
                    _context.Attach(database.Product);
                }
                if (database.RestoredPOC != null && database.RestoredPOC.UserId != 0)
                {
                    _context.Attach(database.RestoredPOC);
                }
                if (database.Server != null && database.Server.ServerId != 0)
                {
                    _context.Attach(database.Server);
                }
                _context.SaveChanges();



                IQueryable<Models.Environment> envs = _context.Environments;
                Models.Environment env = envs.Where(e => e.DatabaseDependency.First().DatabaseId == database.DatabaseId).First();

                try
                {
                    string text = System.IO.File.ReadAllText(env.WorkingDirectory + "/web.config");
                    text = text.Replace(_databaseOldName, database.Name);
                    System.IO.File.WriteAllText(env.WorkingDirectory + "/web.config", text);
                    return Ok();
                }
                catch(Exception ex)
                {
                    Debug.WriteLine("Exception: " + ex.Message);
                    return BadRequest();
                }

                
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
