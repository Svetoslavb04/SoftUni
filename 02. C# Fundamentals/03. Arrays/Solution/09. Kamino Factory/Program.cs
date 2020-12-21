using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    public class Program
    {
        public static void Main()
        {
            int dnaLength = int.Parse(Console.ReadLine());

            int[] bestDNA = new int[dnaLength];
            int bestSum = 0;
            int BestNumberOfSequence = 1;
            int indexOfSequence = int.MaxValue;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Clone them!")
                {
                    break;
                }

                int[] currArr = input.Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int numberOfSequence = 1;
                int currSum = 0;
                int currIndex = -1;

                for (int h = 0; h < currArr.Length; h++)
                {
                    if (currArr[h] == 1)
                    {
                        currSum++;
                    }
                }

                for (int i = 0; i < currArr.Length; ++i)    //0 1 1 0 1 1 1
                {
                    int currBestSeq = 1;

                    for (int j = i + 1; j < currArr.Length; j++)
                    {
                        if (currArr[i] == currArr[j] && currArr[j] == 1)
                        {
                            currBestSeq++;
                            if (currBestSeq > numberOfSequence)
                            {
                                numberOfSequence = currBestSeq;
                                currIndex = i;
                            }
                        }
                        else
                        {
                            if (currBestSeq > numberOfSequence)
                            {
                                numberOfSequence = currBestSeq;
                                currIndex = i;
                            }
                            break;
                        }
                    }
                }

                if (numberOfSequence >= BestNumberOfSequence)
                {
                    if (numberOfSequence > BestNumberOfSequence)
                    {
                        BestNumberOfSequence = numberOfSequence;
                        bestSum = currSum;
                        indexOfSequence = currIndex;

                        for (int l = 0; l < bestDNA.Length; l++)
                        {
                            bestDNA[l] = currArr[l];
                        }
                    }
                    else if (currIndex < indexOfSequence)
                    {
                        BestNumberOfSequence = numberOfSequence;
                        bestSum = currSum;
                        indexOfSequence = currIndex;

                        for (int l = 0; l < bestDNA.Length; l++)
                        {
                            bestDNA[l] = currArr[l];
                        }
                    }
                    else if(currIndex == indexOfSequence)
                    {
                        if (bestSum < currSum)
                        {
                            BestNumberOfSequence = numberOfSequence;
                            bestSum = currSum;
                            indexOfSequence = currIndex;

                            for (int l = 0; l < bestDNA.Length; l++)
                            {
                                bestDNA[l] = currArr[l];
                            }
                        }
                    }
                    
                }
            }
            Console.WriteLine($"Best DNA sample {indexOfSequence + 1} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ",bestDNA));
        }
    }
}
