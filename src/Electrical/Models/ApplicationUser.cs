using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Electrical.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name", Prompt = "First Name", ShortName = "First", Order = 0)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be 2 to 50 characters")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name", Prompt = "Last Name", ShortName = "Last", Order = 1)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be 2 to 50 characters")]
        public string LastName { get; set; }

        [Display(Prompt = "Company", ShortName = "Com.", Order = 2)]
        [DisplayFormat(NullDisplayText = "-")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be 2 to 50 characters")]
        public string Company { get; set; }

        [Display(Prompt = "Title", Order = 3)]
        [DisplayFormat(NullDisplayText = "-")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be 2 to 50 characters")]
        public string Title { get; set; }

        [Display(Prompt = "Trade", Order = 4)]
        [DisplayFormat(NullDisplayText = "-")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be 2 to 50 characters")]
        public string Trade { get; set; }

        [Display(Name = "Roles", Order = 5)]
        [DisplayFormat(NullDisplayText = "-")]
        [DataType(DataType.Text)]
        public string AllRoles { get; set; }

        public virtual ICollection<ToDo> ToDos { get; set; }

        public virtual ICollection<Project> ManagedProjects { get; set; }

        public virtual ICollection<ProjectContact> ProjectsAssignedTo { get; set; }
    }
}
