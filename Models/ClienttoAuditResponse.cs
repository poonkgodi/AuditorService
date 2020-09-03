using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuditorService.Models
{
    public class ClienttoAuditResponse
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

        [Required(ErrorMessage = "ImageName")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be with 2 to 50 characters")]
        public string ImageName { get; set; }

        [Required(ErrorMessage = "ImagePath")]
        [StringLength(250, MinimumLength = 2, ErrorMessage = "Must be with 2 to 250 characters")]
        public string ImagePath { get; set; }

    }
}
