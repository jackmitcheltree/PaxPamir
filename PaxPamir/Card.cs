using PaxPamir.Enums;
using PaxPamir.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace PaxPamir
{
    public class Card
    {
        public CardType CardType { get; private set; }
        public Suit? Suit { get; private set; }
        public Region? Region { get; private set; }
        public Coalition? Patriot { get; private set; }
        public Coalition? Bonus { get; private set; }
        public int? Rank { get; private set; }
        public List<CardAction>? Actions { get; private set; }
        public List<Onplay>? Onplays { get; private set; }
        public List<CardPassive>? Passives { get; private set; }
        public EventOutcome? Purchase { get; private set; }
        public EventOutcome? Discard { get; private set; }

    }
}
