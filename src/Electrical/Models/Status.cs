using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Electrical.Models
{
    public class Status
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StatusId { get; set; }

        [DataType(DataType.Text)]
        [Display(Prompt = "Designation", ShortName = "Des.")]
        [Required(ErrorMessage = "*")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Must be between 3 to 20 characters")]
        public string Designation { get; set; }

        [Display(Name = "List Order")]
        public int ListOrder { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
    }
}
