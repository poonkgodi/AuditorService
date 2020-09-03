using AuditorService.Models;
using AuditorService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace AuditorService.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuditRequestController : ControllerBase
    {
        private readonly ILogger<AuditRequestController> _logger;
        private IRepository<AuditRequest> _repoEntity;
        public AuditRequestController(IRepository<AuditRequest> repoEntity)
        {
            this._repoEntity = repoEntity;
        }

        //Get All Values
        [HttpGet("GetClientRequest")]
        public IEnumerable<AuditRequest> GetClientDetails(string filename,string azure_ContainerName)
        {
            try
            {
                UtilityRepository.AzureFileDownload(filename,azure_ContainerName);
                IEnumerable<AuditRequest> objData = _repoEntity.GetAllasync();
                return objData;
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                return null;
            }
        }

        //Get All Values
        [HttpGet("GetAuditRequest")]
        public IEnumerable<AuditRequest> GetDetails()
        {
            try
            {
                //UtilityRepository.AzureFileDownload();
                IEnumerable<AuditRequest> objData = _repoEntity.GetAllasync();
                return objData;
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                return null;
            }
        }

        //Get specific Values
        [HttpGet("GetAuditRequestDetail/{id:int}")]
        [ProducesResponseType(typeof(IEnumerable<AuditPortfolio>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IEnumerable<AuditRequest> GetSpecificDetail(int id)
        {
            IEnumerable<AuditRequest> objData = _repoEntity.GetAllasync();
            objData = objData.Where(x => x.Id == id);
            return objData;
        }

        // POST api/values
        [HttpPost]
        [Route("PostAuditRequestRecord")]
        public IActionResult AddRequest([FromBody] AuditRequest repoEntity)
        {
            try
            {
                // Send the Audit request to client Application through ServiceBus Queue */
                string bus_connectionString = "Endpoint=sb://auditclientns.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=rDJbSB0nbmK0cs0fw9A0vbLfMyIa8+Zudb3nlCgj6GI=";
                string queuename = "auditmq";
                IQueueClient auditQueue;
                auditQueue = new QueueClient(bus_connectionString, queuename);

                string auditRequestID = repoEntity.AuditRequestID;
                
                string auditRequestMessage = JsonConvert.SerializeObject(repoEntity);
                //auditRequestMessage = repoEntity.ClientId + "|" + auditRequestMessage;
                var message = new Message(Encoding.UTF8.GetBytes(auditRequestMessage));
                auditQueue.SendAsync(message);

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
        [Route("UpdateAuditRequestRecord/{id:int}")]
        public void UpdateRequestData([FromBody] AuditRequest repoEntity, int id)
        {
            try
            {
                int res = _repoEntity.Update(repoEntity);
            }
            catch (Exception ex)
            {
                string Err = ex.Message;
            }
        }

        // PUT api/values
        [HttpDelete]
        [Route("DeleteAuditRequestData/{id:int}")]
        public IActionResult DeleteRequestData(int id)
        {
            try
            {
                var objExistingEntity = _repoEntity.GetAllasync();
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
