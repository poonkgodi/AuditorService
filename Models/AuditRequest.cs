using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace AuditorService.Models
{
    public class AuditRequest
    {
        public int Id { get; set; }
        public string AuditorPortfolioID { get; set; }
        public string AuditRequestID { get; set; }
        public string AuditorID { get; set; }
        [Required]
        public int ClientId { get; set; }
        public string Request { get; set; }
        public DateTime Created_Timestamp { get; set; }
        public string Request_Comment { get; set; }
        public string Response_Comment { get; set; }

    }
}

