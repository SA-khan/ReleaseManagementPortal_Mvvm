using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;
using ServerApp.Models.BindingTargets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Controllers
{
    [Route("api/servers")]
    [ApiController]
    public class ServerValuesController : Controller
    {
        public DataContext _context { get; set; }
        public ServerValuesController(DataContext ctx)
        {
            _context = ctx;
        }
        [HttpGet("{id}")]
        public IActionResult GetServer(long id)
        {
            Server server = _context.Servers.Include(s => s.operatingSystem).Include(s => s.ServerType).FirstOrDefault(s => s.ServerId == id);
            return Ok(server);
        }
        [HttpGet]
        public IActionResult GetServers()
        {
            IQueryable<Server> server = _context.Servers.Include(s => s.operatingSystem).Include(s => s.ServerType);
            return Ok(server);
        }
        [HttpPatch("{id}")]
        public IActionResult UpdateServer(long id, [FromBody] JsonPatchDocument<ServerData> patch)
        {
            Server server = _context.Servers.Include(s => s.operatingSystem).Include(s => s.ServerType).First(s => s.ServerId == id);
            Debug.WriteLine("Server: " + id);
            string serverOldIp = server.Ip;
            Debug.WriteLine("IP: " + serverOldIp);
            string serverOldDomain = server.Domain;
            Debug.WriteLine("Domain: " + serverOldDomain);
            string serverOldUserId = server.UserId;
            Debug.WriteLine("User Id: " + serverOldUserId);
            string serverOldPassword = server.Password;
            Debug.WriteLine("Password: " + serverOldPassword);
            ServerData sData = new ServerData { Server = server };
            patch.ApplyTo(sData, ModelState);
            if( ModelState.IsValid && TryValidateModel(sData))
            {
                if(server.DatabaseServerSupport != null && server.DatabaseServerSupport.DatabaseServerId != 0)
                {
                    _context.Attach(server.DatabaseServerSupport);
                }
                if (server.HybridServerSupport != null && server.HybridServerSupport.HybridServerId != 0)
                {
                    _context.Attach(server.HybridServerSupport);
                }
                if (server.MailServerSupport != null && server.MailServerSupport.MailServerId != 0)
                {
                    _context.Attach(server.MailServerSupport);
                }
                if (server.operatingSystem != null && server.operatingSystem.OperatingSystemId != 0)
                {
                    _context.Attach(server.operatingSystem);
                }
                if (server.PrintServerSupport != null && server.PrintServerSupport.PrintServerId != 0)
                {
                    _context.Attach(server.PrintServerSupport);
                }
                if (server.ServerType != null && server.ServerType.ServerTypeId != 0)
                {
                    _context.Attach(server.ServerType);
                }
                if (server.WebServerSupport != null && server.WebServerSupport.WebServerId != 0)
                {
                    _context.Attach(server.WebServerSupport);
                }

                _context.SaveChanges();

                
                //foreach (Models.Environment environment in envs)
                //{
                //    if (environment.Server != null)
                //    {
                //        if (environment.Server.ServerId == id)
                //        {
                //            Debug.WriteLine("env go: " + environment.EnvironmentId);
                //            env = environment;
                //        }
                //        else
                //        {
                //            Debug.WriteLine("env got: " + environment.EnvironmentId);
                //        }
                //    }
                //}

                //Models.Environment env = _context.Environments.Where(e => e.DatabaseDependency.First().Server.ServerId == id).First();
                //Debug.WriteLine("Environment ID: " + env.EnvironmentId);
                try
                {

                    IQueryable<Database> dbs = _context.Databases.Where(dbs => dbs.Server.ServerId == id);
                    Models.Database db = dbs.Include(d => d.Environment).FirstOrDefault();
                    Debug.WriteLine("db id: " + db.Environment.EnvironmentId);
                    IQueryable<Server> servers = _context.Servers.Where(srsv => srsv.ServerId == id );

                    Debug.WriteLine("envs count: " + _context.Environments.Count());
                    IQueryable<Models.Environment> envs = _context.Environments.Where(e => e.EnvironmentId == db.Environment.EnvironmentId);
                    Models.Environment env = envs.First();

                    string text = System.IO.File.ReadAllText(env.WorkingDirectory + "/web.config");
                    text = text.Replace(serverOldIp, server.Ip).Replace(serverOldDomain, server.Domain).Replace(serverOldUserId, server.UserId).Replace(serverOldPassword, server.Password);
                    System.IO.File.WriteAllText(env.WorkingDirectory + "/web.config", text);
                    return Ok();
                }
                catch (Exception ex)
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
