using System.ComponentModel.DataAnnotations;

namespace Electrical.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "First Name", Prompt = "First Name", ShortName = "First", Order = 0)]
        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be 2 to 50 characters")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Last Name", Prompt = "Last Name", ShortName = "Last", Order = 1)]
        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be 2 to 50 characters")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "Email", Order = 2)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Prompt = "Password", Order = 3)]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password", Prompt = "Confirm Password", Order = 4)]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Text)]
        [Display(Prompt = "Company", ShortName = "Com.", Order = 5)]
        [DisplayFormat(NullDisplayText = "-")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be 2 to 50 characters")]
        public string Company { get; set; }

        [DataType(DataType.Text)]
        [Display(Prompt = "Title", Order = 6)]
        [DisplayFormat(NullDisplayText = "-")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be 2 to 50 characters")]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        [Display(Prompt = "Trade", Order = 7)]
        [DisplayFormat(NullDisplayText = "-")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be 2 to 50 characters")]
        public string Trade { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone", Prompt = "Phome", Order = 8)]
        [DisplayFormat(NullDisplayText = "-")]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
