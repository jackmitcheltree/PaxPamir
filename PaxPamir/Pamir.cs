using PaxPamir.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxPamir
{
    public class Pamir
    {
        private GameState _state { get; set; }
        public Pamir(List<Card> CardList, List<(PlayerColor color, string name)> PlayerInput)
        {
            List<RegionState>? map = new List<RegionState>()
            {
                new RegionState
                {
                    Region = Region.Transcaspia,
                    Ruler = PlayerColor.None
                },
                new RegionState
                {
                    Region = Region.Persia,
                    Ruler = PlayerColor.None
                },
                new RegionState
                {
                    Region = Region.Herat,
                    Ruler = PlayerColor.None
                },
                new RegionState
                {
                    Region = Region.Kabul,
                    Ruler = PlayerColor.None
                },
                new RegionState
                {
                    Region = Region.Kandahar,
                    Ruler = PlayerColor.None
                },
                new RegionState
                {
                    Region = Region.Punjab,
                    Ruler = PlayerColor.None
                },
            };
            //Map = Enum.GetValues(typeof(Region)).Cast<Region>().Select(d => new RegionState { Region = d, Ruler = PlayerColor.None }).ToList();

            //Validate the deck
            bool validDeck = true;
            //Check for dominance checks
            validDeck &= CardList.Where(card => card.Purchase == EventOutcome.DominanceCheck).Count() == 4;
            validDeck &= CardList.Where(card => card.Purchase != EventOutcome.DominanceCheck && card.CardType == CardType.EventCard).Count() == 6;
            validDeck &= CardList.Where(card => card.CardType == CardType.PlayerCard).Count() == (30 + 6 * PlayerInput.Count());
            if (!validDeck)
            {
                throw new Exception(); //todo
            }

            //Shuffle and create Deck
            Stack<Card> deck = ShuffleDeck(CardList, PlayerInput);

            //Create market
            List<MarketSlot> marketTopRow = new List<MarketSlot>();
            List<MarketSlot> marketBottomRow = new List<MarketSlot>();

            for (int i = 0; i < 6; i++)
            {
                marketTopRow.Add(new MarketSlot { Card = deck.Pop()});
                marketBottomRow.Add(new MarketSlot { Card = deck.Pop()});
            }

            List<BlockSlot> blockList = new List<BlockSlot>();
            InitializeBlockList(blockList, Coalition.British);
            InitializeBlockList(blockList, Coalition.Russia);
            InitializeBlockList(blockList, Coalition.Afgan);

            //Player related inits
            PlayerInput = PlayerInput.OrderBy(x => Random.Shared.Next()).ToList();
            Dictionary<PlayerColor , PlayerState> players = new Dictionary<PlayerColor, PlayerState>();
            for (int i = 0; i < PlayerInput.Count(); i++)
            {
                var input = PlayerInput[i];
                int leftPlayer = i + 1;
                int rightPlayer = i - 1;

                if (leftPlayer == PlayerInput.Count())
                {
                    leftPlayer = 0;
                }

                if (rightPlayer == -1)
                {
                    rightPlayer = PlayerInput.Count() - 1;
                }

                var playerstate = new PlayerState
                {
                    Color = input.color,
                    Money = 4,
                    Cylinders = Enumerable.Range(0, 10)
                        .Select(x => new Cylinder 
                        { 
                            Color = input.color, State = CylinderState.OnBoard
                        }).ToList(),
                    LeftPlayer = PlayerInput[leftPlayer].color,
                    RightPlayer = PlayerInput[rightPlayer].color,
                    Coalition = Coalition.None,
                    PlayerName = input.name
                };

                players[input.color] = playerstate;
            }

            _state = new GameState
            {
                Map = map,
                Players = players,
                MarketTopRow = marketTopRow,
                MarketBottomRow = marketBottomRow,
                Deck = deck,
                BlockList = blockList,
                FavoredSuit = Suit.Political,
                ActivePlayer = PlayerInput[0].color,
                PromptedPlayer = PlayerColor.None
            };

        }

        private static Stack<Card> ShuffleDeck(List<Card> CardList, List<(PlayerColor, string)> PlayerInput)
        {
            //Shuffle deck
            var playerCards = CardList.Where(card => card.CardType == CardType.PlayerCard).OrderBy(x => Random.Shared.Next()).ToArray();
            var eventCards = CardList.Where(card => card.Purchase != EventOutcome.DominanceCheck && card.CardType == CardType.EventCard).OrderBy(x => Random.Shared.Next()).ToArray();
            var dominanceChecks = CardList.Where(card => card.Purchase == EventOutcome.DominanceCheck).ToArray();

            Stack<Card> deck = new Stack<Card>();
            int currentPlayerCardCount = 0;
            int grabPlayerCard = 5 + PlayerInput.Count();

            //Stack deck
            for (int i = 0; i < 4; i++)
            {
                var batch_temp = playerCards.Skip(currentPlayerCardCount)
                    .Take(grabPlayerCard)
                    .Append(eventCards[i])
                    .Append(dominanceChecks[i])
                    .OrderBy(x => Random.Shared.Next());

                currentPlayerCardCount += grabPlayerCard;

                foreach (var item in batch_temp)
                {
                    deck.Push(item);
                }
            }

            var batch = playerCards.Skip(currentPlayerCardCount)
                    .Take(grabPlayerCard)
                    .Append(eventCards[4])
                    .Append(eventCards[5])
                    .OrderBy(x => Random.Shared.Next());

            currentPlayerCardCount += grabPlayerCard;

            foreach (var item in batch)
            {
                deck.Push(item);
            }

            batch = playerCards.Skip(currentPlayerCardCount)
                    .Take(grabPlayerCard)
                    .OrderBy(x => Random.Shared.Next());

            currentPlayerCardCount += grabPlayerCard;

            foreach (var item in batch)
            {
                deck.Push(item);
            }

            return deck;
        }

        private static void InitializeBlockList(List<BlockSlot> BlockList, Coalition coalition)
        {
            for (int i = 0; i < 12; i++)
            {
                BlockList.Add(new BlockSlot
                {
                    State = BlockState.None,
                    Coalition = coalition
                });
            }
        }
    }
}
