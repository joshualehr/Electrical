using System.Collections.Generic;

namespace Electrical.ViewModels.Project
{
    public class DetailsViewModel : Models.Project
    {
        public int BuildingCount { get; set; }

        public int AreaCount { get; set; }

        public IList<StatusViewModel> BuildingsStatus { get; set; }
    }
}
