using System;
using System.Linq;
using System.Collections.Generic;

namespace SamplePoker
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] card = { "10h", "Jh", "Qh", "Ah", "Kh" };
            string[] card = { "3h", "5h", "Qs", "9h", "Ad" };
            //string[] card = { "10s", "10c", "8d", "10d", "10h" };

            var poker = PokerHandRanking(card);
            Console.WriteLine(poker);
        }

        public static string PokerHandRanking(IEnumerable<string> myCards)
        {
            var returnWording = "";
            Deck deck = new Deck();
            var cards = new List<Card>();
            foreach (var card in myCards)
            {
                if (card.Length == 3)
                {
                    var rank = card.Substring(0, 2);
                    var suit = card.Substring(2, 1);
                    cards.Add(new Card { Suit = deck.getSuit(suit), Rank = deck.getRank(rank) });
                }
                else
                {
                    var rank = card.Substring(0, 1);
                    var suit = card.Substring(1, 1);
                    cards.Add(new Card { Suit = deck.getSuit(suit), Rank = deck.getRank(rank) });
                }
            }

            Hand hand = new Hand { Cards = cards };

            if (hand.IsRoyalStraightFlush)
            {
                returnWording = "Royal Flush";
            }
            else if (hand.IsStraightFlush)
            {
                returnWording = "Straight Flush";
            }
            else if (hand.IsFourOfAKind)
            {
                returnWording = "Four of a Kind";
            }
            else if (hand.IsFullHouse)
            {
                returnWording = "Full House";
            }
            else if (hand.IsFlush)
            {
                returnWording = "Flush";
            }
            else if (hand.IsStraight)
            {
                returnWording = "Straight";
            }
            else if (hand.IsThreeOfAKind)
            {
                returnWording = "Three of a Kind";
            }
            else if (hand.IsTwoPair)
            {
                returnWording = "Two Pair";
            }
            else if (hand.IsPair)
            {
                returnWording = "Pair";
            }
            else
            {
                returnWording = "High Card";
            }

            return returnWording;
        }
    }
}
