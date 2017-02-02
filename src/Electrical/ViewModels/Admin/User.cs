using Electrical.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Electrical.ViewModels.Admin
{
    public class RoleCheckBox
    {
        public string Id { get; set; }
        public bool IsChecked { get; set; }
        public string Name { get; set; }
    }

    public class UserIndexViewModel
    {
        public ICollection<ApplicationUser> Users { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Trade { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "Please enter a valid phone number, (555) 555-5555")]
        [StringLength(14, ErrorMessage = "Use format (555) 555-5555"), MinLength(14, ErrorMessage = "Use format (555) 555-5555")]
        public string PhoneNumber { get; set; }

        public IList<RoleCheckBox> Roles { get; set; }
    }

    public class DeleteUserViewModel
    {
        public string UserId { get; set; }
    }
}