using PaxPamir.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxPamir
{
    public class PlayerState
    {  
        public PlayerColor Color {  get; set; }
        public int Money { get; set; }
        public List<Cylinder> Cylinders { get; set; } = new List<Cylinder>();
        public List<Card> Hand { get; set; } = new List<Card>();
        public List<CourtSlot> Court {  get; set; } = new List<CourtSlot>();
        public CourtSlot? Leftmost { get; set; }
        public CourtSlot? Rightmost { get; set; }
        public PlayerColor LeftPlayer {  get; set; }
        public PlayerColor RightPlayer { get; set; }
        public int VP { get; set; }
        public Coalition Coalition { get; set; }
        public int Influence { get; set; }
        public List<Card> Prizes { get; set; } = new List<Card>();
        public List<CardPassive> ActiveCardPassives { get; set; } = new List<CardPassive>();
        public List<EventOutcome> ActiveEventOutcomes { get; set; } = new List<EventOutcome>();
        public string? PlayerName {  get; set; }
    }
}
