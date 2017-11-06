using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silverton.Models
{
    public class LogsViewModels
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CameraId { get; set; }


        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Status")]
        public bool Status { get; set; }

        [Required]
        [Display(Name = "IP Address")]
        [EmailAddress]
        public string IPAddress { get; set; }
    }
}