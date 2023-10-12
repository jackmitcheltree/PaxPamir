using PaxPamir.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxPamir
{
    public class RegionState
    {
        public Region Region { get; set; }
        public PlayerColor Ruler { get; set; }
        public List<BlockSlot> Blocks { get; set; } = new List<BlockSlot>();
    }
}
