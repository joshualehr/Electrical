using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Electrical.Models
{
    public class UnitOfMeasure
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UnitOfMeasureId { get; set; }

        [DataType(DataType.Text)]
        [Display(Prompt = "Designation", ShortName = "Des.")]
        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be between 2 to 50 characters")]
        public string Designation { get; set; }

        public virtual ICollection<AreaMaterial> AreaMaterial { get; set; }

        public virtual ICollection<ModelMaterial> ModelMaterial { get; set; }
    }
}
