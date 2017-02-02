using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Electrical.Models
{
    public class Document
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DocumentId { get; set; }

        [DataType(DataType.Text)]
        [Display(Prompt = "Designation", ShortName = "Des.")]
        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Must be between 3 to 50 characters")]
        public string Designation { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Prompt = "Description", ShortName = "Disc.")]
        [DisplayFormat(NullDisplayText = "-")]
        public string Description { get; set; }

        [DataType(DataType.Url)]
        [DisplayFormat(HtmlEncode = true)]
        [Required(ErrorMessage = "*")]
        public string FileLink { get; set; }

        public virtual ICollection<AreaDocument> AreaDocuments { get; set; }

        public virtual ICollection<BuildingDocument> BuildingDocuments { get; set; }

        public virtual ICollection<ModelDocument> ModelDocuments { get; set; }

        public virtual ICollection<ProjectDocument> ProjectDocuments { get; set; }
    }
}