using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silverton.Models
{
    public class NotificationsViewModels
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CameraId { get; set; }


        [Required]
        [Display(Name = "Notification Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Scenario Name")]
        public string ScenarioName { get; set; }

        [Required]
        [Display(Name = "Notifications Type")]
        public string Type { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}