using System;
using System.Collections.Generic;
using System.Text;

namespace PenScan.Models
{
    public class ProjectPhase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }//0 = not started, 1 = active, 2 = completed
    }
}
