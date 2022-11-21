using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePoker
{
    public class Hand
    {
        public IEnumerable<Card> Cards { get; set; }

        public bool Contains(Rank val)
        {
            return Cards.Where(c => c.Rank == val).Any();
        }

        /// <summary>
        /// Two cards of the same rank.
        /// </summary>
        public bool IsPair
        {
            get
            {
                return Cards.GroupBy(h => h.Rank)
                           .Where(g => g.Count() == 2)
                           .Count() == 1;
            }
        }

        /// <summary>
        /// Two different Pair.
        /// </summary>
        public bool IsTwoPair
        {
            get
            {
                return Cards.GroupBy(h => h.Rank)
                            .Where(g => g.Count() == 2)
                            .Count() == 2;
            }
        }

        /// <summary>
        /// Three cards of the same rank.
        /// </summary>
        public bool IsThreeOfAKind
        {
            get
            {
                return Cards.GroupBy(h => h.Rank)
                            .Where(g => g.Count() == 3)
                            .Any();
            }
        }

        /// <summary>
        /// Five cards in a sequence, but not of the same suit.
        /// </summary>
        public bool IsStraight
        {
            get
            {
                // If there is an Ace, we have to handle the 10,J,Q,K,A case, which isn't handled by the code
                // below because Ace is normally 0
                if (Contains(Rank.Ace) &&
                    Contains(Rank.King) &&
                    Contains(Rank.Queen) &&
                    Contains(Rank.Jack) &&
                    Contains(Rank.Ten))
                {
                    return true;
                }

                var ordered = Cards.OrderBy(h => h.Rank).ToArray();
                var straightStart = (int)ordered.First().Rank;
                for (var i = 1; i < ordered.Length; i++)
                {
                    if ((int)ordered[i].Rank != straightStart + i)
                        return false;
                }

                return true;
            }

        }

        /// <summary>
        /// Any five cards of the same suit, not in sequence.
        /// </summary>
        public bool IsFlush
        {
            get
            {
                return Cards.GroupBy(h => h.Suit).Count() == 1;
            }
        }

        /// <summary>
        /// Three of a Kind with a Pair.
        /// </summary>
        public bool IsFullHouse
        {
            get
            {
                return IsPair && IsThreeOfAKind;
            }
        }

        /// <summary>
        /// Four cards of the same rank.
        /// </summary>
        public bool IsFourOfAKind
        {
            get
            {
                return Cards.GroupBy(h => h.Rank)
                            .Where(g => g.Count() == 4)
                            .Any();
            }
        }

        /// <summary>
        /// Five cards in sequence, all with the same suit.
        /// </summary>
        public bool IsStraightFlush
        {
            get
            {
                return IsStraight && IsFlush;
            }
        }

        /// <summary>
        /// A, K, Q, J, 10, all with the same suit.
        /// </summary>
        public bool IsRoyalStraightFlush
        {
            get
            {
                return IsStraight && IsFlush && Contains(Rank.Ace) && Contains(Rank.King);
            }
        }
    }
}
