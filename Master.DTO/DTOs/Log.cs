using System;
using System.Collections.Generic;
using System.Text;

namespace Master.Entity.Models
{
    public partial class Log
    {
        public int LogId { get; set; }
        public int? Id { get; set; }
        public string Idtype { get; set; }
        public string LogType { get; set; }
        public int? WorkerId { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime LogDate { get; set; }
        public string EventDesc { get; set; }
        public string TableChanged { get; set; }
        public string FieldChanged { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public double? Amount { get; set; }
        public int? SilcarId { get; set; }
    }
}
