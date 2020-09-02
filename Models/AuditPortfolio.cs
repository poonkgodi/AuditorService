using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuditorService.Models
{
    public class AuditPortfolio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AuditorPortfolioID { get; set; }
        [Required(ErrorMessage = "AuditorID Must be provided")]
        [StringLength(50, MinimumLength = 2)]
        public string AuditorID { get; set; }
        [Required(ErrorMessage = "Please provide AuditorName")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Length must be within 2 to 100 characters")]
        public string AuditorName { get; set; }
        [Required]
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTime Created_Timestamp { get; set; }
    }
}