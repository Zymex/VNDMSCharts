using System;
using System.Collections.Generic;
using System.Text;

namespace VietnamDMSx.Vietnam.EFModelViews
{
    public class TopDefectsElement
    {
        public int RowNumber { get; set; }
        public int Quantity { get; set; }
        public int Accum { get; set; }
        public int Acc { get; set; }
        public string NCCode { get; set; }
        public string NCDes { get; set; }
        public string Type { get; set; }
    }
}
