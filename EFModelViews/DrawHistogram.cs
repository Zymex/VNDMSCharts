using System;
using System.Collections.Generic;
using System.Text;

namespace VietnamDMSx.Vietnam.EFModelViews
{
    public class DrawHistogram
    {
        public decimal Points { get; set; }
        public int CountP { get; set; }
        public int UCL { get; set; }
        public int LCL { get; set; }
        public string Type { get; set; }
    }
}
