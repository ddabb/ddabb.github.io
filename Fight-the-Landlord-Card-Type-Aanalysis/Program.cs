using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            var allCardType = InitData();
            var handCardCount = 4;
            var result = Analysis(allCardType, handCardCount);


            Console.WriteLine("手牌数为" + handCardCount + "时,可能的打法情况为:");
            int index = 0;
            foreach (var enablelist2 in result)
            {
                index += 1;
                Console.Write(index + ": ");
                foreach (var choose in enablelist2)
                {
                    if (choose.CardSum != 0)
                    {
                        Console.Write(" " + choose + "   ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("所有牌型列举完成");
            Console.ReadKey();
        }

        /// <summary>
        /// 分析可能的牌型组合
        /// </summary>
        /// <param name="allcardlist">所有的有效牌型</param>
        /// <param name="handCardCount">手牌数量,最多20张</param>
        private static List<List<CardType>> Analysis(List<List<CardType>> allcardlist, int handCardCount = 20)
        {
            List<List<CardType>> tempresult = Verification(allcardlist[0], allcardlist[1], handCardCount);
            for (int i = 2; i < allcardlist.Count; i++)
            {
                tempresult = Verification(tempresult, allcardlist[i], handCardCount);
            }

            var result = tempresult.Where(c => c.Sum(d => d.CardSum) == handCardCount);
            return result.ToList();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <returns></returns>
        private static List<List<CardType>> InitData()
        {
            List<CardType> one = new List<CardType>
            {
                new CardType("单张", 1, 0),
                new CardType("单张", 1, 1),
                new CardType("单张", 1, 2),
                new CardType("单张", 1, 3),
                new CardType("单张", 1, 4),
                new CardType("单张", 1, 5),
                new CardType("单张", 1, 6),
                new CardType("单张", 1, 7),
                new CardType("单张", 1, 8),
                new CardType("单张", 1, 9),
                new CardType("单张", 1, 10),
                new CardType("单张", 1, 11),
                new CardType("单张", 1, 12),
                new CardType("单张", 1, 13),
                new CardType("单张", 1, 14),
                new CardType("单张", 1, 15),
                new CardType("单张", 1, 16),
                new CardType("单张", 1, 17),
                new CardType("单张", 1, 18),
                new CardType("单张", 1, 19),
                new CardType("单张", 1, 20)
            };
            List<CardType> couple = new List<CardType>
            {
                new CardType("对子", 2, 0),
                new CardType("对子", 2, 1),
                new CardType("对子", 2, 2),
                new CardType("对子", 2, 3),
                new CardType("对子", 2, 4),
                new CardType("对子", 2, 5),
                new CardType("对子", 2, 6),
                new CardType("对子", 2, 7),
                new CardType("对子", 2, 8),
                new CardType("对子", 2, 9),
                new CardType("对子", 2, 10)
            };
            List<CardType> coupleThree = new List<CardType>
            {
                new CardType("3连对", 6, 0),
                new CardType("3连对", 6, 1),
                new CardType("3连对", 6, 2),
                new CardType("3连对", 6, 3),
            };
            List<CardType> coupleFour = new List<CardType>
            {
                new CardType("4连对", 8, 0),
                new CardType("4连对", 8, 1),
                new CardType("4连对", 8, 2),
            };
            List<CardType> coupleFive = new List<CardType>
            {
                new CardType("5连对", 10, 0),
                new CardType("5连对", 10, 1),
                new CardType("5连对", 10, 2),
            };
            List<CardType> coupleSix = new List<CardType>
            {
                new CardType("6连对", 12, 0),
                new CardType("6连对", 12, 1),
            };
            List<CardType> coupleSeven = new List<CardType>
            {
                new CardType("7连对", 14, 0),
                new CardType("7连对", 14, 1),
            };
            List<CardType> coupleEight = new List<CardType>
            {
                new CardType("8连对", 16, 0),
                new CardType("8连对", 16, 1),
            };
            List<CardType> coupleNine = new List<CardType>
            {
                new CardType("9连对", 18, 0),
                new CardType("9连对", 18, 1),
            };
            List<CardType> coupleTen = new List<CardType>
            {
                new CardType("10连对", 20, 0),
                new CardType("10连对", 20, 1),
            };
            List<CardType> triple = new List<CardType>
            {
                new CardType("3张牌", 3, 0),
                new CardType("3张牌", 3, 1),
                new CardType("3张牌", 3, 2),
                new CardType("3张牌", 3, 3),
                new CardType("3张牌", 3, 4),
                new CardType("3张牌", 3, 5),
                new CardType("3张牌", 3, 6)
            };
            List<CardType> tripleTwo = new List<CardType>
            {
                new CardType("两个3张牌", 6, 0),
                new CardType("两个3张牌", 6, 1),
                new CardType("两个3张牌", 6, 2),
                new CardType("两个3张牌", 6, 3)
            };
            List<CardType> tripleThree = new List<CardType>
            {
                new CardType("3个3张牌", 9, 0),
                new CardType("3个3张牌", 9, 1),
                new CardType("3个3张牌", 9, 2),
            };
            List<CardType> tripleFour = new List<CardType>
            {
                new CardType("4个3张牌", 12, 0),
                new CardType("4个3张牌", 12, 1),
            };
            List<CardType> tripleFive = new List<CardType>
            {
                new CardType("5个3张牌", 15, 0),
                new CardType("5个3张牌", 15, 1),
            };
            List<CardType> tripleSix = new List<CardType>
            {
                new CardType("6个3张牌", 16, 0),
                new CardType("6个3张牌", 18, 1),
            };
            List<CardType> tripleTakeOne = new List<CardType>
            {
                new CardType("3张牌带1张", 4, 0),
                new CardType("3张牌带1张", 4, 1),
                new CardType("3张牌带1张", 4, 2),
                new CardType("3张牌带1张", 4, 3),
                new CardType("3张牌带1张", 4, 4),
                new CardType("3张牌带1张", 4, 5),
            };
            List<CardType> tripleTakeOne_two = new List<CardType>
            {
                new CardType("两个3张牌带1张", 8, 0),
                new CardType("两个3张牌带1张", 8, 1),
                new CardType("两个3张牌带1张", 8, 2),
            };
            List<CardType> tripleTakeOne_three = new List<CardType>
            {
                new CardType("3个3张牌带1张", 12, 0),
                new CardType("3个3张牌带1张", 12, 1),
            };
            List<CardType> tripleTakeOne_four = new List<CardType>
            {
                new CardType("4个3张牌带1张", 16, 0),
                new CardType("4个3张牌带1张", 16, 1),
            };
            List<CardType> tripleTakeOne_five = new List<CardType>
            {
                new CardType("5个3张牌带1张", 20, 0),
                new CardType("5个3张牌带1张", 20, 1),
            };
            List<CardType> tripleTakeCouple = new List<CardType>
            {
                new CardType("3张牌带1对", 5, 0),
                new CardType("3张牌带1对", 5, 1),
                new CardType("3张牌带1对", 5, 2),
                new CardType("3张牌带1对", 5, 3),
                new CardType("3张牌带1对", 5, 4),
            };
            List<CardType> tripleTakeCouple_two = new List<CardType>
            {
                new CardType("两个3张牌带1对", 10, 0),
                new CardType("两个3张牌带1对", 10, 1),
                new CardType("两个3张牌带1对", 10, 2),
            };
            List<CardType> tripleTakeCouple_three = new List<CardType>
            {
                new CardType("3个3张牌带1对", 15, 0),
                new CardType("3个3张牌带1对", 15, 1),
            };
            List<CardType> tripleTakeCouple_four = new List<CardType>
            {
                new CardType("4个3张牌带1对", 20, 0),
                new CardType("4个3张牌带1对", 20, 1),
            };
            List<CardType> bomb = new List<CardType>
            {
                new CardType("炸弹", 4, 0),
                new CardType("炸弹", 4, 1),
                new CardType("炸弹", 4, 2),
                new CardType("炸弹", 4, 3),
                new CardType("炸弹", 4, 4),
                new CardType("炸弹", 4, 5),
            };
            List<CardType> bombTakeTwo = new List<CardType>
            {
                new CardType("炸弹带两张", 6, 0),
                new CardType("炸弹带两张", 6, 1),
                new CardType("炸弹带两张", 6, 2),
                new CardType("炸弹带两张", 6, 3),
            };
            List<CardType> bombTakeTwoCouple = new List<CardType>
            {
                new CardType("炸弹带两双", 8, 0),
                new CardType("炸弹带两双", 8, 1),
                new CardType("炸弹带两双", 8, 2),
            };
            List<CardType> straight_five = new List<CardType>
            {
                new CardType("5张牌的顺子", 5, 0),
                new CardType("5张牌的顺子", 5, 1),
                new CardType("5张牌的顺子", 5, 2),
                new CardType("5张牌的顺子", 5, 3),
                new CardType("5张牌的顺子", 5, 4),
            };
            List<CardType> straight_six = new List<CardType>
            {
                new CardType("6张牌的顺子", 6, 0),
                new CardType("6张牌的顺子", 6, 1),
                new CardType("6张牌的顺子", 6, 2),
                new CardType("6张牌的顺子", 6, 3),
            };
            List<CardType> straight_seven = new List<CardType>
            {
                new CardType("7张牌的顺子", 7, 0),
                new CardType("7张牌的顺子", 7, 1),
                new CardType("7张牌的顺子", 7, 2),
            };
            List<CardType> straight_eight = new List<CardType>
            {
                new CardType("8张牌的顺子", 8, 0),
                new CardType("8张牌的顺子", 8, 1),
                new CardType("8张牌的顺子", 8, 2),
            };
            List<CardType> straight_nine = new List<CardType>
            {
                new CardType("9张牌的顺子", 9, 0),
                new CardType("9张牌的顺子", 9, 1),
                new CardType("9张牌的顺子", 9, 2),
            };
            List<CardType> straight_ten = new List<CardType>
            {
                new CardType("10张牌的顺子", 10, 0),
                new CardType("10张牌的顺子", 10, 1),
                new CardType("10张牌的顺子", 10, 2),
            };
            List<CardType> straight_eleven = new List<CardType>
            {
                new CardType("11张牌的顺子", 11, 0),
                new CardType("11张牌的顺子", 11, 1),
            };
            List<CardType> straight_twelve = new List<CardType>
            {
                new CardType("12张牌的顺子", 12, 0),
                new CardType("12张牌的顺子", 12, 1),
            };
            List<CardType> bigbang = new List<CardType>
            {
                new CardType("王炸", 2, 0),
                new CardType("王炸", 2, 1),
            };

            List<List<CardType>> allcardlist = new List<List<CardType>>
            {
                one,
                couple,
                coupleThree,
                coupleFour,
                coupleFive,
                coupleSix,
                coupleSeven,
                coupleEight,
                coupleNine,
                coupleTen,
                triple,
                tripleTwo,
                tripleThree,
                tripleFour,
                tripleFive,
                tripleSix,
                tripleTakeOne,
                tripleTakeOne_two,
                tripleTakeOne_three,
                tripleTakeOne_four,
                tripleTakeOne_five,
                tripleTakeCouple,
                tripleTakeCouple_two,
                tripleTakeCouple_three,
                tripleTakeCouple_four,
                bomb,
                bombTakeTwo,
                bombTakeTwoCouple,
                straight_five,
                straight_six,
                straight_seven,
                straight_eight,
                straight_nine,
                straight_ten,
                straight_eleven,
                straight_twelve,
                bigbang
            };
            return allcardlist;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="enableList">可用牌型组合</param>
        /// <param name="enablelist2">可用牌型组合</param>
        /// <param name="handCardCount">手牌数</param>
        /// <returns></returns>
        public static List<List<CardType>> Verification(List<CardType> enableList, List<CardType> enablelist2,
            int handCardCount)
        {
            List<List<CardType>> result = new List<List<CardType>>();

            foreach (var cardType in enableList)
            {
                foreach (var cardType2 in enablelist2)
                {
                    if (cardType.CardSum + cardType2.CardSum > handCardCount) continue;
                    result.Add(new List<CardType> {cardType, cardType2});
                }
            }

            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="enableList">可用牌型组合</param>
        /// <param name="enablelist2">可用牌型组合2</param>
        /// <param name="handCardCount">手牌数</param>
        /// <returns></returns>
        public static List<List<CardType>> Verification(List<List<CardType>> enableList, List<CardType> enablelist2,
            int handCardCount)
        {
            List<List<CardType>> result = new List<List<CardType>>();

            foreach (var cardTypeList in enableList)
            {
                var cardCountSum = cardTypeList.Sum(c => c.CardSum); //已选方案的总手牌数
                foreach (var cardType in enablelist2)
                {
                    if (cardCountSum + cardType.CardSum > handCardCount) continue;
                    List<CardType> temp = cardTypeList.ToList();
                    temp.Add(cardType);
                    result.Add(temp);
                }
            }

            return result;
        }
    }

    /// <summary>
    /// 牌型
    /// </summary>
    public class CardType
    {
        /// <summary>
        /// 牌型名称
        /// </summary>
        public string TypeName;

        /// <summary>
        /// 张数
        /// </summary>
        public int CardCount;

        /// <summary>
        /// 次数
        /// </summary>
        public int Times;

        /// <summary>
        /// 消耗牌张数
        /// </summary>
        public int CardSum;


        public CardType(string typeName, int cardCount, int times)
        {
            this.TypeName = typeName;
            this.CardCount = cardCount;
            this.Times = times;
            this.CardSum = cardCount * times;
        }


        public override string ToString()
        {
            return string.Format("牌型为：{0},每次消耗{2},出了{1}次,共消耗掉{3}张牌"
                , TypeName, Times, CardCount, CardSum);
        }
    }
}