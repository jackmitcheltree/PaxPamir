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
    public class PlayerCard: ICard
    {
        public Suit Suit { get; private set; }
        public Region Region { get; private set; }
        public Coalition Patriot { get; private set; }
        public Coalition Bonus { get; private set; }
        public int Rank { get; private set; }
        public List<CardAction> Actions { get; private set; }
        public List<Onplay> Onplays { get; private set; }

        public CardType CardType { get; private set; }

        public PlayerCard(Suit suit, Region region, Coalition patriot, Coalition bonus, int rank, List<CardAction> actions, List<Onplay> onplays)
        {
            CardType = CardType.PlayerCard;
            Suit = suit;
            Region = region;
            Patriot = patriot;
            Bonus = bonus;
            Rank = rank;
            Actions = actions;
            Onplays = onplays;
        }

        public void Discard()
        {
            throw new NotImplementedException();
        }

        public void Purchase()
        {
            throw new NotImplementedException();
        }
    }
}
