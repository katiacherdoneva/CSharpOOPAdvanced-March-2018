using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Number_Wars
{
    class Program
    {
        static void Main()
        {
            string[] cardFirstPlayer = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] cardSecondPlayer = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Queue<string> firstPlayer = new Queue<string>(cardFirstPlayer);
            Queue<string> secondPlayer = new Queue<string>(cardSecondPlayer);
            int index = 0;
            while (true)
            {
                index++;

                string firstCard = firstPlayer.Dequeue();
                string secondCard = secondPlayer.Dequeue();

                int firstCardSum = int.Parse(firstCard.Substring(0, firstCard.Length - 1));
                int secondCardSum = int.Parse(secondCard.Substring(0, firstCard.Length - 1));

                GiveCardsOnWinner(ref firstPlayer, ref secondPlayer, firstCard, secondCard, firstCardSum, secondCardSum);

                if (index >= 1000000)
                {
                    break;
                }

                if (firstPlayer.Count == 0 && secondPlayer.Count == 0)
                {
                    break;
                }
            }

            PrintResult(firstPlayer, secondPlayer, index);
        }

        private static void PrintResult(Queue<string> firstPlayer, Queue<string> secondPlayer, int index)
        {
            if (firstPlayer.Count == 0 && secondPlayer.Count == 0)
            {
                Console.WriteLine($"Draw after {index} turns");
            }
            else if (firstPlayer.Count == 0 && secondPlayer.Count > 0)
            {
                Console.WriteLine($"Second player wins after {index} turns");
            }
            else if (secondPlayer.Count == 0 && firstPlayer.Count > 0)
            {
                Console.WriteLine($"First player wins after {index} turns");
            }
            else
            {
                int sumOfCardsFirst = firstPlayer.Sum(x => SumOfCard(x));
                int sumOfCardsSecond = firstPlayer.Sum(x => SumOfCard(x));

                if (sumOfCardsFirst > sumOfCardsSecond)
                {
                    Console.WriteLine($"First player wins after {index} turns");
                }
                else if (sumOfCardsSecond > sumOfCardsFirst)
                {
                    Console.WriteLine($"Second player wins after {index} turns");
                }
                else
                {
                    Console.WriteLine($"Draw after {index} turns");
                }
            }
        }

        private static void GiveCardsOnWinner(ref Queue<string> firstPlayer, ref Queue<string> secondPlayer,
            string firstCard, string secondCard, int firstCardSum, int secondCardSum)
        {
            if (firstCardSum > secondCardSum)
            {
                firstPlayer.Enqueue(firstCard);
                firstPlayer.Enqueue(secondCard);
            }
            else if (secondCardSum > firstCardSum)
            {
                secondPlayer.Enqueue(secondCard);
                secondPlayer.Enqueue(firstCard);
            }
            else
            {
                List<string> cardsFirst = new List<string>();
                List<string> cardsSecond = new List<string>();

                FindWinnerOnEqualCards(ref firstPlayer, ref secondPlayer, cardsFirst, cardsSecond);
            }
        }

        private static void FindWinnerOnEqualCards(ref Queue<string> firstPlayer, ref Queue<string> secondPlayer,
            List<string> cardsFirst, List<string> cardsSecond)
        {
            bool hasWinner = false;
            List<string> allCardsOnField = new List<string>();
            while (!hasWinner)
            {
                if (firstPlayer.Count - 3 == 0 || secondPlayer.Count - 3 == 0)
                {
                    return;
                }
                else if (firstPlayer.Count - 3 <= 2 || secondPlayer.Count - 3 <= 2)
                {
                    for (int i = 1; i < firstPlayer.Count; i++)
                    {
                        cardsFirst.Add(firstPlayer.Dequeue());
                        cardsSecond.Add(secondPlayer.Dequeue());
                    }
                }
                    

                int firstCardsSum = GetSum(cardsFirst);
                int secondCardsSum = GetSum(cardsSecond);

                allCardsOnField.AddRange(cardsFirst);
                allCardsOnField.AddRange(cardsSecond);

                hasWinner = FindWinner(firstCardsSum, secondCardsSum,
                    allCardsOnField,
                    ref firstPlayer, ref secondPlayer);
            }

        }

        private static bool FindWinner(int firstCardsSum, int secondCardsSum,
            List<string> allCardsOnField,
            ref Queue<string> firstPlayer, ref Queue<string> secondPlayer)
        {
            bool hasWinner = false;

            if (firstCardsSum > secondCardsSum)
            {
                hasWinner = true;
                GiveCards(ref firstPlayer, allCardsOnField.OrderByDescending(x => SumOfCard(x)).ToList);
            }
            else if (secondCardsSum > firstCardsSum)
            {
                hasWinner = true;
                GiveCards(ref secondPlayer, allCardsOnField.OrderByDescending(x => SumOfCard(x)).ToList);
            }
            return hasWinner;
        }

        private static void GiveCards(ref Queue<string> firstPlayer, Func<List<string>> toList)
        {
            throw new NotImplementedException();
        }

        static Func<string, int> SumOfCard => (x) => Convert.ToByte(x[x.Length - 1]) - 96 + int.Parse(x.Substring(0, x.Length - 2));

        private static int GetSum(List<string> cardsFirst)
        {
            int lettersSum = 0;
            for (int i = 0; i < cardsFirst.Count; i++)
            {
                lettersSum += Convert.ToByte(cardsFirst[i][cardsFirst[i].Length - 1]) - 96;
            }

            return lettersSum;
        }

    }
}
