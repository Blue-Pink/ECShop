using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{


    public class BSCategory : BLCategory
    {
        public System.Int32 BSID
        { get; set; }
        public new System.Int32 BLID
        { get; set; }
        public new System.String BLName
        { get; set; }
        public string BLName1 { get; set; }
    }
}
