using System;
using System.Collections.Generic;

namespace Electrical.ViewModels.Project
{
    public class IndexViewModel
    {
        public ICollection<IndexItemViewModel> Projects { get; set; }
    }

    public class IndexItemViewModel
    {
        public Guid ProjectId { get; set; }
        public string Designation { get; set; }
    }
}
