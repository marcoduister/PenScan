using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenScan.Models
{
    public class File
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FullPath { get; set; }
        public string ContentType { get; set; }
        public int ProjectId { get; set; }
        public int projectfaseId { get; set; }


    }
}
