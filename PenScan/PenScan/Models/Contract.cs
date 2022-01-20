using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenScan.Models
{
    public class Contract
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string signature { get; set; }
        public bool Confirmd { get; set; }
        public int ProjectId { get; set; }
    }
}
