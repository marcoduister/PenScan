using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenScan.Models
{
    public class Project
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public Status Status { get; set; }

    }
}
