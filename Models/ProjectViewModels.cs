using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Silverton.Models
{
    public class ProjectViewModels
    {
        [Required]
        [Display(Name = "Project Name")]
        public string Name { get; set; }

        [Key]
        [Required]
        [Display(Name = "Project Code")]
        public string Code { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Client")]
        public string Client { get; set; }

        [Required]
        [Display(Name = "Consultant")]
        public string Consultant { get; set; }

        [Required]
        [Display(Name = "Contractor")]
        public string Contractor { get; set; }

        [Required]
        [Display(Name = "Sector")]
        public string Sector { get; set; }

        [Required]
        [Display(Name = "Plot")]
        public string Plot { get; set; }
    }
}