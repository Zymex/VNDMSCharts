using System;
using System.Collections.Generic;
using System.Text;

namespace VietnamDMSx.Vietnam.EFModelViews
{
    public class RawDataElements
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public string Part { get; set; }
        public string Wo { get; set; }
        public string Lot { get; set; }
        public string Plate { get; set; }
        public string OperatorId { get; set; }
        public int? F2 { get; set; }
        public int? EngIndex { get; set; }
        public string Note2 { get; set; }
        public string Rs2 { get; set; }
        public int? F3 { get; set; }
        public string Note3 { get; set; }
        public string Rs3 { get; set; }
        public string Family { get; set; }
        public string Type { get; set; }
        public decimal USL { get; set; }
    }
}
