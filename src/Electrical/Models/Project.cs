using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Electrical.Models
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProjectId { get; set; }

        [DataType(DataType.Text)]
        [Display(Prompt = "Designation", ShortName = "Des.")]
        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Must be between 3 to 50 characters")]
        public string Designation { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Job Code", Prompt = "Job Code", ShortName = "Code")]
        public string JobCode { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Prompt = "Description", ShortName = "Disc.")]
        [DisplayFormat(NullDisplayText = "-")]
        public string Description { get; set; }

        [DataType(DataType.Text)]
        [Display(Prompt = "Address")]
        [DisplayFormat(NullDisplayText = "-")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Must be between 3 to 100 characters")]
        public string Address { get; set; }

        [DataType(DataType.Text)]
        [Display(Prompt = "City")]
        [DisplayFormat(NullDisplayText = "-")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be between 2 to 50 characters")]
        public string City { get; set; }

        [DataType(DataType.Text)]
        [Display(Prompt = "State")]
        [DisplayFormat(NullDisplayText = "-")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Must be 2 characters")]
        public string State { get; set; }

        [DataType(DataType.PostalCode)]
        [DisplayFormat(NullDisplayText = "-")]
        [Display(Name = "Postal Code", Prompt = "Postal Code", ShortName = "PO")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Please enter 5 digits")]
        public int? PostalCode { get; set; }

        [Display(Prompt = "Project Manager")]
        [ForeignKey("ProjectManager")]
        [Required]
        [StringLength(450)]
        public string ProjectManagerId { get; set; }

        public virtual ApplicationUser ProjectManager { get; set; }

        public virtual ICollection<Building> Buildings { get; set; }

        public virtual ICollection<Model> Models { get; set; }

        public virtual ICollection<ProjectDocument> ProjectDocuments { get; set; }

        public virtual ICollection<ProjectContact> ProjectContacts { get; set; }
    }

    public class ProjectContact
    {
        public Guid ProjectId { get; set; }

        [ForeignKey("Contact")]
        [Required]
        [StringLength(450)]
        public string ContactId { get; set; }

        public virtual Project Project { get; set; }

        public virtual ApplicationUser Contact { get; set; }
    }

    public class ProjectDocument
    {
        public Guid ProjectId { get; set; }

        public Guid DocumentId { get; set; }

        public virtual Project Project { get; set; }

        public virtual Document Document { get; set; }
    }
}
