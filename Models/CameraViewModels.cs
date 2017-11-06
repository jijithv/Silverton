using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;


namespace Silverton.Models
{
    public class CameraViewModels
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CameraId { get; set; }

        
        [Required]
        [Display(Name = "Camera Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Camera Make")]
        public string Make { get; set; }

        [Required]
        [Display(Name = "Camera Model")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Operating Time From")]
        public DateTime From { get; set; }
        [Required]
        [Display(Name = "Operating Time To")]
        public DateTime To { get; set; }

        [Required]
        [Display(Name = "Week days")]
        public string[] WeekdaysListsAsString { get; set; }

        [Required]
        [Display(Name = "Live View")]
        public bool LiveView { get; set; }

        [Required]
        [Display(Name = "Extrernal Link")]
        public string ExtrernalLink { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Video Speed")]
        public string VideoSpeed { get; set; }

        [Required]
        [Display(Name = "Continuous Loop")]
        public bool ContinuousLoop { get; set; }


        public IEnumerable<SelectListItem> _weekdaysList { get; set; }
        public CameraViewModels()
        {
            _weekdaysList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Sunday", Text = "Sunday" },
                new SelectListItem { Value = "Monday", Text = "Monday" },
                new SelectListItem { Value = "Tuesday", Text = "Tuesday" },
                new SelectListItem { Value = "Wednesday", Text = "Wednesday" },
                new SelectListItem { Value = "Thursday", Text = "Thursday" },
                new SelectListItem { Value = "Friday", Text = "Friday" },
                new SelectListItem { Value = "Saturday", Text = "Saturday" },
            };
        }
    }
}