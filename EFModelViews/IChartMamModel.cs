using System;
using System.Collections.Generic;
using System.Text;

namespace VietnamDMSx.Vietnam.EFModelViews
{
    public class IChartMamModel
    {
        public int RowNumber { get; set; }
        public decimal I { get; set; }
        public decimal UCLI { get; set; }
        public decimal LCLI { get; set; }
        public decimal AVGI { get; set; }
        public string Type { get; set; }
    }
}
