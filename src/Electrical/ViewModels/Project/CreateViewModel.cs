using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Electrical.ViewModels.Project
{
    public class CreateViewModel : Models.Project
    {
        [Display(Name = "Manager", Prompt = "Assign Project To...", ShortName = "Manager")]
        public IEnumerable<SelectListItem> Users { get; set; }
    }
}
