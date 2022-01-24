using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PenScan.Models
{
    public class ScanItem
    {
        public int Id { get; set; }
        public string Ipaddress { get; set; }
        public string State { get; set; }
        public string HostName { get; set; }
        public string Protocol { get; set; }
        public int Port { get; set; }
    }
}
