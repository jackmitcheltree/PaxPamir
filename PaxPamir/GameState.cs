using PaxPamir.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxPamir
{
    public class GameState
    {
        public List<RegionState>? Map { get; set; }
        public Dictionary<PlayerColor , PlayerState>? Players { get; set; }
        public List<MarketSlot> MarketTopRow { get; set; } = new List<MarketSlot>();
        public List<MarketSlot> MarketBottomRow { get; set; } = new List<MarketSlot>();
        public Stack<Card> Deck { get; set; } = new Stack<Card>();
        public List<BlockSlot> BlockList { get; set; } = new List<BlockSlot>();
        public Suit FavoredSuit { get; set; }
        public PlayerColor ActivePlayer {  get; set; }
        public PlayerColor PromptedPlayer { get; set; }
        public Object Prompt { get; set; } = new Object(); //variable that stores the request for input

    }
}
