using PaxPamir.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxPamir
{
    public class CourtSlot
    {
        public List<Cylinder> Spies {  get; set; } = new List<Cylinder>();
        public Card ?Card { get; set; }
        public CourtSlot? Left { get; set; } 
        public CourtSlot? Right { get; set; }
    }
}
