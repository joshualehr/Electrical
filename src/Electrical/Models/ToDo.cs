using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Electrical.Models
{
    public class ToDo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ToDoId { get; set; }

        [Required()]
        public Guid AreaId { get; set; }

        [Display(Prompt = "Assigned To")]
        [ForeignKey("AssignedTo")]
        [Required]
        [StringLength(450)]
        public string AssignedToId { get; set; }

        public Guid? ParentToDoId { get; set; }

        [DataType(DataType.Text)]
        [Display(Prompt = "Heading", ShortName = "Head")]
        [Required(ErrorMessage = "*")]
        [StringLength(20)]
        public string Heading { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Prompt = "Description", ShortName = "Disc.")]
        [Required(ErrorMessage = "*")]
        [StringLength(200)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Started On", Prompt = "Started", ShortName = "Started")]
        public DateTime? StartOn { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Completed On", Prompt = "Completed", ShortName = "Completed")]
        public DateTime? CompletedOn { get; set; }

        [Display(Name = "List Order", Prompt = "Order", ShortName = "Order")]
        public short ListOrder { get; set; }

        public virtual ToDo ParentToDo { get; set; }

        public virtual Area Area { get; set; }

        public virtual ApplicationUser AssignedTo { get; set; }

        public virtual ICollection<ToDo> ChildToDos { get; set; }
    }
}