using AuditorService.Models;
using AuditorService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AuditorService.Controllers
{
    public class AuditPortfolioController : ControllerBase
    {
        private readonly ILogger<AuditPortfolioController> _logger;
        private IRepository<AuditPortfolio> _repoEntity;
        public AuditPortfolioController(IRepository<AuditPortfolio> repoEntity)
        {
            this._repoEntity = repoEntity;
        }

        //Get All Values
        [HttpGet("GetAuditor")]
        public IEnumerable<AuditPortfolio> GetDetails()
        {
            try
            {
                IEnumerable<AuditPortfolio> objData = _repoEntity.GetAllasync();
                return objData;
            }
            catch(Exception ex)
            {
               string errorMessage =  ex.Message;
               return null;
            }
        }

        //Get specific Values
        [HttpGet("GetSpecificDetail/{id:int}")]
        [ProducesResponseType(typeof(IEnumerable<AuditPortfolio>),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IEnumerable<AuditPortfolio> GetSpecificDetail(int id)
        {
            IEnumerable<AuditPortfolio> objData = _repoEntity.GetAllasync();
            objData = objData.Where(x => x.Id == id);
            return objData;
        }

        // POST api/values
        [HttpPost]
        [Route("PostRecord")]
        public IActionResult Add([FromBody] AuditPortfolio repoEntity)
        {
            try
            {
                int res = _repoEntity.Insert(repoEntity);
                if (res != 0)
                {
                    return Ok(res);
                }
                return Forbid();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // PUT api/values
        [HttpPut]
        [Route("UpdateRecord/{id:int}")]
        public IActionResult UpdateData([FromBody] AuditPortfolio repoEntity, int id)
        {
            try
            {
                int res = _repoEntity.Update(repoEntity);
                if (res != 0)
                {
                    return Ok(res);
                }
                return Forbid();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // PUT api/values
        [HttpDelete]
        [Route("DeleteData/{id:int}")]
        public IActionResult DeleteData(int id)
        {
            try
            {
                var objExistingEntity =  _repoEntity.GetAllasync();
                var objEntity = objExistingEntity.Where(x => x.Id == id).FirstOrDefault();
                int res = _repoEntity.Delete(objEntity);
                if (res != 0)
                {
                    return Ok(res);
                }
                return Forbid();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
