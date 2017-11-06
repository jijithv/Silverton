using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silverton.Models
{
    public class ScenarioViewModels
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CameraId { get; set; }


        [Required]
        [Display(Name = "Scenario Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Status")]
        public bool Status { get; set; }

        [Required]
        [Display(Name = "Camera")]
        public string Camera { get; set; }

        [Required]
        [Display(Name = "Working Days")]
        public string WorkingDays { get; set; }

        [Required]
        [Display(Name = "Operating Time From")]
        public DateTime From { get; set; }
        [Required]
        [Display(Name = "Operating Time To")]
        public DateTime To { get; set; }
    }
}