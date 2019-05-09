using System;
using System.Collections.Generic;
using System.Text;

namespace VietnamDMSx.Vietnam.EFModelViews
{
    public class BathLifeOfEtchChemical
    {
        public DateTime Date { get; set; }
        public decimal CumulativeDissolvedMetal { get; set; }
        public decimal USL { get; set; }
        public string Part { get; set; }
    }
}
