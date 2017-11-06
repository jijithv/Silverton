using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silverton.Models
{
    public class UserSetupViewModels
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CameraId { get; set; }


        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Status")]
        public bool Type { get; set; }

        [Required]
        [Display(Name = "Projects")]
        public bool Projects { get; set; }

        [Required]
        [Display(Name = "Access Privilege")]
        public bool AccessPrivilege { get; set; }


    }
}