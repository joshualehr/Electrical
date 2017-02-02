using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Electrical.Models
{
    public class Building
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BuildingId { get; set; }

        [DataType(DataType.Text)]
        [Display(Prompt = "Designation", ShortName = "Des.")]
        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Must be between 3 to 50 characters")]
        public string Designation { get; set; }

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
        [Display(Name = "Postal Code", Prompt = "PO", ShortName = "PO")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Please enter 5 digits")]
        public int? PostalCode { get; set; }

        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<Area> Areas { get; set; }

        public virtual ICollection<BuildingDocument> BuildingDocuments { get; set; }
    }

    public class BuildingDocument
    {
        // see ApplicationDbContext.OnModelCreating
        public Guid BuildingId { get; set; }

        // see ApplicationDbContext.OnModelCreating
        public Guid DocumentId { get; set; }

        public virtual Building Building { get; set; }

        public virtual Document Document { get; set; }
    }
}
