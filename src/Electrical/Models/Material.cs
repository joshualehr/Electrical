using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Electrical.Models
{
    public class Material
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MaterialId { get; set; }

        [DataType(DataType.Text)]
        [Display(Prompt = "Designation", ShortName = "Des.")]
        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be between 2 to 50 characters")]
        public string Designation { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Prompt = "Description", ShortName = "Disc.")]
        [Required(ErrorMessage = "*")]
        public string Description { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image", Prompt = "Image", ShortName = "Img")]
        [DisplayFormat(HtmlEncode = true)]
        public string ImagePath { get; set; }

        [Display(Name = "Unit of Measure", Prompt = "U/M", ShortName = "U/M")]
        public Guid UnitOfMeasureId { get; set; }

        public virtual UnitOfMeasure UnitOfMeasure { get; set; }

        public virtual ICollection<AreaMaterial> AreaMaterial { get; set; }

        public virtual ICollection<ModelMaterial> ModelMaterial { get; set; }
    }
}
