using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Electrical.Models
{
    public class Model
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ModelId { get; set; }

        [Required]
        [StringLength(50)]
        public string Designation { get; set; }

        public string Description { get; set; }

        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<Area> Areas { get; set; }

        public virtual ICollection<ModelMaterial> ModelMaterial { get; set; }

        public virtual ICollection<ModelDocument> ModelDocuments { get; set; }
    }

    public class ModelMaterial
    {
        public Guid ModelId { get; set; }

        public Guid MaterialId { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(0.01, 10000, ErrorMessage = "Must be between 0.01 and 10,000")]
        public double Quantity { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(0.1, 10000, ErrorMessage = "Must be between 0.1 and 10,000")]
        public double RoughQuantity { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(0.1, 10000, ErrorMessage = "Must be between 0.1 and 10,000")]
        public double FinishQuantity { get; set; }

        public Guid UnitOfMeasureId { get; set; }

        public virtual UnitOfMeasure UnitOfMeasure { get; set; }

        public virtual Model Model { get; set; }

        public virtual Material Material { get; set; }
    }

    public class ModelDocument
    {
        public Guid ModelId { get; set; }

        public Guid DocumentId { get; set; }

        public virtual Model Model { get; set; }

        public virtual Document Document { get; set; }
    }
}
