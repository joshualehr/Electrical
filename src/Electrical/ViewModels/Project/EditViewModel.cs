using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Electrical.ViewModels.Project
{
    public class EditViewModel
    {
        public Guid ProjectId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "50 characters max")]
        public string Designation { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Job Code")]
        [StringLength(20, ErrorMessage = "20 characters max")]
        public string PurchaseOrder { get; set; }

        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "100 characters max")]
        public string Address { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "50 characters max")]
        public string City { get; set; }

        [DataType(DataType.Text)]
        [StringLength(2, ErrorMessage = "2 letter abbreviation")]
        public string State { get; set; }

        [DataType(DataType.PostalCode)]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Please enter a 5 digit code.")]
        public int? PostalCode { get; set; }

        [Required]
        [Display(Name = "Assigned To")]
        [StringLength(128, ErrorMessage = "128 characters max")]
        public string UserId { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; }
    }
}
