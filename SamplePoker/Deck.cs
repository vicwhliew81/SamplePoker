using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePoker
{
    public class Deck
    {
        public Deck()
        {
        }

        public Suit getSuit(string suit)
        {
            switch (suit)
            {
                case "h":
                    return Suit.Hearts;
                case "s":
                    return Suit.Spades;
                case "d":
                    return Suit.Diamonds;
                case "c":
                    return Suit.Clubs;
                default:
                    throw new Exception($"Suit {suit} not found.");
            }
        }
        public Rank getRank(string rank)
        {
            switch (rank)
            {
                case "2":
                    return Rank.Two;
                case "3":
                    return Rank.Three;
                case "4":
                    return Rank.Four;
                case "5":
                    return Rank.Five;
                case "6":
                    return Rank.Six;
                case "7":
                    return Rank.Seven;
                case "8":
                    return Rank.Eight;
                case "9":
                    return Rank.Nine;
                case "10":
                    return Rank.Ten;
                case "J":
                    return Rank.Jack;
                case "Q":
                    return Rank.Queen;
                case "K":
                    return Rank.King;
                case "A":
                    return Rank.Ace;
                default:
                    throw new Exception($"card Rank {rank} not found.");
            }
        }
    }
}
