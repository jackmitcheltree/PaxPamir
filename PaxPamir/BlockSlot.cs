using PaxPamir.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxPamir
{
    public class BlockSlot
    {
        public BlockState State { get; private set; }
        public Coalition Coalition { get; private set; }
        public Tuple<(Region, Region)> ?Location { get; private set; }

    }
}
