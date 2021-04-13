using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;
using ServerApp.Models.BindingTargets;

namespace ServerApp.Controllers
{
    [Route("api/releases")]
    [ApiController]
    public class ReleaseValuesController : Controller
    {
        public DataContext _context;

        public ReleaseValuesController(DataContext ctx)
        {
            _context = ctx;
        }

        [HttpGet("{id}")]
        public Release GetRelease(long id)
        {
            Release query = _context.Releases.Include( r => r.Company ).ThenInclude( r => r.Industry ).Include( r => r.DevelopedBy ).Include(r => r.DeployedBy ).Include(r => r.EnvironmentType).Include(r => r.Product).Include(r => r.QualityAssurance).ThenInclude(r => r.PerformedBy).Include(r => r.QualityAssurance).ThenInclude(r => r.VerifiedBy).FirstOrDefault(r => r.ReleaseId == id);

            if (query.Product.Releases != null)
            {
                query.Product.Releases = query.Product.Releases.Select(r => new Release { PatchNumber = r.PatchNumber, DevelopedBy = r.DevelopedBy, DeployedDate = r.DeployedDate, QualityAssurance = r.QualityAssurance, Remarks = r.Remarks, Title = r.Title, Description = r.Description, CreatedDate = r.CreatedDate, DeployedBy = r.DeployedBy, ReleaseId = r.ReleaseId }).ToList();
            }
            
            return query;
        }

        [HttpGet]
        public IEnumerable<Release> GetReleases(bool updated = true)
        {
            IEnumerable<Release> query = null;
            if (updated)
            {
                query = _context.Releases.Include(r => r.Company).ThenInclude(r => r.Industry).Include(r => r.Company).ThenInclude(r => r.TechnicalPoc).Include(r => r.DevelopedBy).Include(r => r.DeployedBy).ThenInclude(r => r.Region).Include(r => r.Product).Include(r => r.Environment).Include(r => r.EnvironmentType).Include(r => r.Environment).ThenInclude(r => r.Server).Include(r => r.QualityAssurance).ThenInclude(r => r.PerformedBy).Include(r => r.QualityAssurance).ThenInclude(r => r.VerifiedBy).OrderBy(r => r.Company.Name ).OrderBy(r => r.Product.Name).OrderByDescending(r => r.DeployedDate).Distinct();
            }
            else
            {
                query = _context.Releases.Include(r => r.DeployedBy);
            }
            foreach(var item in query)
            {
                if(item.Product.Releases != null)
                {
                    item.Product.Releases = item.Product.Releases.Select( r => new Release { PatchNumber = r.PatchNumber, DevelopedBy = r.DevelopedBy ,DeployedDate = r.DeployedDate, QualityAssurance = r.QualityAssurance, Remarks = r.Remarks, Title = r.Title, Description = r.Description, CreatedDate = r.CreatedDate, DeployedBy = r.DeployedBy, ReleaseId = r.ReleaseId } ).ToList();
                }
            }
            return query;
        }

        [HttpPost]
        public IActionResult AddRelease([FromBody] ReleaseData rData)
        {
            if (ModelState.IsValid)
            {
                Release release = rData.Release;
                if (release.Company != null && release.Company.CompanyId != 0)
                {
                    _context.Attach(release.Company);
                }
                if (release.DeployedBy != null && release.DeployedBy.UserId != 0)
                {
                    _context.Attach(release.DeployedBy);
                }
                if (release.DevelopedBy != null && release.DevelopedBy.UserId != 0)
                {
                    _context.Attach(release.DevelopedBy);
                }
                if (release.EnvironmentType != null && release.EnvironmentType.EnvironmentTypeId != 0)
                {
                    _context.Attach(release.EnvironmentType);
                }
                if (release.Product != null && release.Product.ProductId != 0)
                {
                    _context.Attach(release.Product);
                }
                if (release.QualityAssurance != null && release.QualityAssurance.QualityAssuranceId != 0)
                {
                    _context.Attach(release.QualityAssurance);
                }
                _context.Add(release);
                _context.SaveChanges();
                return Ok(release.ReleaseId);
            }

            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditRelease(long id, [FromBody] ReleaseData rData)
        {
            if (ModelState.IsValid)
            {
                Release release = rData.Release;
                release.ReleaseId = id;
                if (release.Company != null && release.Company.CompanyId != 0)
                {
                    _context.Attach(release.Company);
                }
                if (release.DeployedBy != null && release.DeployedBy.UserId != 0)
                {
                    _context.Attach(release.DeployedBy);
                }
                if (release.DevelopedBy != null && release.DevelopedBy.UserId != 0)
                {
                    _context.Attach(release.DevelopedBy);
                }
                if (release.EnvironmentType != null && release.EnvironmentType.EnvironmentTypeId != 0)
                {
                    _context.Attach(release.EnvironmentType);
                }
                if (release.Product != null && release.Product.ProductId != 0)
                {
                    _context.Attach(release.Product);
                }
                if (release.QualityAssurance != null && release.QualityAssurance.QualityAssuranceId != 0)
                {
                    _context.Attach(release.QualityAssurance);
                }
                _context.Update(release);
                _context.SaveChanges();
                return Ok();
            }

            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateRelease(long id,[FromBody] JsonPatchDocument<ReleaseData> patch)
        {
                Release release = _context.Releases.Include(r => r.Company).ThenInclude(r => r.Industry).Include(r => r.Company).ThenInclude(r => r.TechnicalPoc).Include(r => r.DevelopedBy).Include(r => r.DeployedBy).ThenInclude(r => r.Region).Include(r => r.Product).Include(r => r.Environment).Include(r => r.EnvironmentType).Include(r => r.Environment).ThenInclude(r => r.Server).Include(r => r.QualityAssurance).ThenInclude(r => r.PerformedBy).Include(r => r.QualityAssurance).ThenInclude(r => r.VerifiedBy).OrderBy(r => r.Company.Name).OrderBy(r => r.Product.Name).OrderByDescending(r => r.DeployedDate).FirstOrDefault(r => r.ReleaseId == id);
                ReleaseData rData = new ReleaseData { Release = release };
                patch.ApplyTo(rData, ModelState);
                if( ModelState.IsValid && TryValidateModel(rData) )
                {
                    if(release.Company != null && release.Company.CompanyId != 0)
                    {
                        _context.Attach(release.Company);
                    }
                    if(release.DeployedBy != null && release.DeployedBy.UserId != 0)
                    {
                        _context.Attach(release.DeployedBy);
                    }
                    if (release.DevelopedBy != null && release.DevelopedBy.UserId != 0)
                    {
                        _context.Attach(release.DevelopedBy);
                    }
                    if (release.Environment != null && release.Environment.EnvironmentId != 0)
                    {
                        _context.Attach(release.Environment);
                    }
                    if (release.EnvironmentType != null && release.EnvironmentType.EnvironmentTypeId != 0)
                    {
                        _context.Attach(release.EnvironmentType);
                    }
                    if (release.Product != null && release.Product.ProductId != 0)
                    {
                        _context.Attach(release.Product);
                    }
                    if (release.QualityAssurance != null && release.QualityAssurance.QualityAssuranceId != 0)
                    {
                        _context.Attach(release.QualityAssurance);
                    }
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRelease(long id)
        {
                _context.Releases.Remove(new Release { ReleaseId = id });
                _context.SaveChanges();
                return Ok();
        }

    }
}
