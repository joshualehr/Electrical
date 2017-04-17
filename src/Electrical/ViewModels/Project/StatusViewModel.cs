using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electrical.ViewModels.Project
{
    public class StatusViewModel
    {
        public Guid BuildingId { get; set; }

        public string Building { get; set; }

        public int AreaCount { get; set; }

        public IDictionary<string, double> Statuses { get; set; }

    }
}
