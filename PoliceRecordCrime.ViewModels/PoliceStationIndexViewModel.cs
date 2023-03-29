using PoliceRecordCrime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceRecordCrime.ViewModels
{
    public class PoliceStationIndexViewModel
    {
        public IEnumerable<PoliceStation> PoliceStations { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
