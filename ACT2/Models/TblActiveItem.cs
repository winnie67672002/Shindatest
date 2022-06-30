using System;
using System.Collections.Generic;

namespace ACT2.Models
{
    public partial class TblActiveItem
    {
        public int CItemId { get; set; }
        public string CItemName { get; set; } = null!;
        public DateTime ActiveDt { get; set; }
    }
}
