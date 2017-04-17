using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Electrical.Models
{
    public class Area
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AreaId { get; set; }

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

        [DataType(DataType.Date)]
        [Display(Name = "Status Changed", ShortName = "Changed")]
        [Required]
        public DateTime StatusChanged { get; set; }

        public Guid BuildingId { get; set; }

        public Guid StatusId { get; set; }

        public Guid? ModelId { get; set; }

        public virtual Building Building { get; set; }

        public virtual Status Status { get; set; }

        public virtual Model Model { get; set; }

        public virtual ICollection<AreaMaterial> AreaMaterial { get; set; }

        public virtual ICollection<AreaDocument> AreaDocuments { get; set; }

        public virtual ICollection<ToDo> ToDos { get; set; }
    }

    public class AreaMaterial
    {
        public Guid AreaId { get; set; }

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

        public virtual Area Area { get; set; }

        public virtual Material Material { get; set; }
    }

    public class AreaDocument
    {
        public Guid AreaId { get; set; }

        public Guid DocumentId { get; set; }

        public virtual Area Area { get; set; }

        public virtual Document Document { get; set; }
    }
}
