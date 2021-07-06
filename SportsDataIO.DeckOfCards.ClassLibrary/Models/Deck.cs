using System;
using System.Collections.Generic;
using System.Linq;

namespace SportsDataIO.DeckOfCards.ClassLibrary
{
    public class Deck
    {
        public Card[] Cards { get; set; }

        public Deck()
        {
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            Cards = Suits().SelectMany(suit => Ranks().Select(rank => new Card { Suit = suit, Rank = rank })).ToArray();
            Shuffle();
        }

        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < Cards.Length; i++)
            {
                int r = i + rand.Next(Cards.Length - i);

                var temp = Cards[r];
                Cards[r] = Cards[i];
                Cards[i] = temp;
            }
        }

        public Card Draw()
        {
            var topCard = Cards[Cards.Length - 1];

            var cards = new List<Card>(Cards);
            cards.Remove(topCard);
            Cards = cards.ToArray();

            return topCard;
        }

        public override string ToString()
        {
            var str = Cards.Select(c => c.ToString());
            return string.Join("\n", str);
        }

        private IEnumerable<string> Suits()
        {
            yield return "♣";
            yield return "♦";
            yield return "♥";
            yield return "♠";
        }

        private IEnumerable<string> Ranks()
        {
            yield return "2";
            yield return "3";
            yield return "4";
            yield return "5";
            yield return "6";
            yield return "7";
            yield return "8";
            yield return "9";
            yield return "10";
            yield return "J";
            yield return "Q";
            yield return "K";
            yield return "A";
        }
    }
}
