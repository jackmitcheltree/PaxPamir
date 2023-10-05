using PaxPamir.Enums;
using PaxPamir.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaxPamir
{
    public class Card
    {
        [JsonInclude]
        public CardType CardType { get; private set; }
        [JsonInclude]
        public Suit? Suit { get; private set; }
        [JsonInclude]
        public Region? Region { get; private set; }
        [JsonInclude]
        public Coalition? Patriot { get; private set; }
        [JsonInclude]
        public Coalition? Bonus { get; private set; }
        [JsonInclude]
        public int? Rank { get; private set; }
        [JsonInclude]
        public List<CardAction>? Actions { get; private set; }
        [JsonInclude]
        public List<Onplay>? Onplays { get; private set; }
        [JsonInclude]
        public List<CardPassive>? Passives { get; private set; }
        [JsonInclude]
        public EventOutcome? Purchase { get; private set; }
        [JsonInclude]
        public EventOutcome? Discard { get; private set; }

    }
}
