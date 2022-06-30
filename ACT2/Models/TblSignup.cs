using System;
using System.Collections.Generic;

namespace ACT2.Models
{
    public partial class TblSignup
    {
        public int CId { get; set; }
        public string CName { get; set; } = null!;
        public string CMobile { get; set; } = null!;
        public string CEmail { get; set; } = null!;
        public DateTime CCreateDt { get; set; }
    }
}
