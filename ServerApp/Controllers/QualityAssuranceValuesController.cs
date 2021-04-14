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
    [Route("api/qualityassurances")]
    [ApiController]
    public class QualityAssuranceValuesController : Controller
    {
        private DataContext _context;
        private QualityAssuranceValuesController(DataContext ctx)
        {
            _context = ctx;
        }

        [HttpGet("{id}")]
        public IActionResult GetQualityAssurance(long id)
        {
            QualityAssurance result = _context.QualityAssurances.Include(qa => qa.PerformedBy).Include(qa => qa.VerifiedBy).FirstOrDefault(qa => qa.QualityAssuranceId == id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllQualityAssurance()
        {
            IEnumerable<QualityAssurance> result = _context.QualityAssurances.Include(qa => qa.PerformedBy).Include(qa => qa.VerifiedBy);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddQualityAssurance([FromBody] QualityAssuranceData qualityAssurance)
        {
            if (ModelState.IsValid)
            {
                QualityAssurance qa = qualityAssurance.QualityAssurance;
                _context.QualityAssurances.Add(qa);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditQualityAssurance(long id, [FromBody] QualityAssuranceData qualityAssurance)
        {
            if (ModelState.IsValid)
            {
                QualityAssurance qa = qualityAssurance.QualityAssurance;
                qa.QualityAssuranceId = id;
                if(qa.PerformedBy != null && qa.PerformedBy.UserId != 0)
                {
                    _context.Attach(qa.PerformedBy);
                }
                if (qa.VerifiedBy != null && qa.VerifiedBy.UserId != 0)
                {
                    _context.Attach(qa.VerifiedBy);
                }
                _context.QualityAssurances.Update(qa);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateQualityAssurance(long id, [FromBody] JsonPatchDocument<QualityAssuranceData> patch)
        {
            QualityAssurance qa = _context.QualityAssurances.Find(id);
            QualityAssuranceData qad = new QualityAssuranceData { QualityAssurance = qa };
            patch.ApplyTo(qad, ModelState);
            if (ModelState.IsValid && TryValidateModel(patch)) { 
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQualityAssurance(long id)
        {
            QualityAssurance qa = new QualityAssurance { QualityAssuranceId = id };
            _context.QualityAssurances.Remove(qa);
            _context.SaveChanges();
            return Ok();
        }

    }
}
