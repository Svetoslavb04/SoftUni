using System;

namespace _06._Operations_Between_Numbers
{
    public class Program
    {
        public static void Main()
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            char operatorSymbol = char.Parse(Console.ReadLine());

            switch (operatorSymbol)
            {
                case '+':

                    if ((firstNumber + secondNumber) % 2 == 0)
                    {
                        Console.WriteLine($"{firstNumber} {operatorSymbol} {secondNumber} = {firstNumber + secondNumber} - even");

                    }
                    else
                    {
                        Console.WriteLine($"{firstNumber} {operatorSymbol} {secondNumber} = {firstNumber + secondNumber} - odd");
                    }

                    break;

                case '-':

                    if ((firstNumber - secondNumber) % 2 == 0)
                    {
                        Console.WriteLine($"{firstNumber} {operatorSymbol} {secondNumber} = {firstNumber - secondNumber} - even");

                    }
                    else
                    {
                        Console.WriteLine($"{firstNumber} {operatorSymbol} {secondNumber} = {firstNumber - secondNumber} - odd");
                    }

                    break;

                case '*':

                    if ((firstNumber * secondNumber) % 2 == 0)
                    {
                        Console.WriteLine($"{firstNumber} {operatorSymbol} {secondNumber} = {firstNumber * secondNumber} - even");

                    }
                    else
                    {
                        Console.WriteLine($"{firstNumber} {operatorSymbol} {secondNumber} = {firstNumber * secondNumber} - odd");
                    }

                    break;

                case '/':

                    if (secondNumber == 0)
                    {
                        Console.WriteLine($"Cannot divide {firstNumber} by zero");
                    }
                    else
                    {

                        Console.WriteLine($"{firstNumber} {operatorSymbol} {secondNumber} = {firstNumber / secondNumber:F2}");
                    }
                    break;

                case '%':

                    if (secondNumber == 0)
                    {
                        Console.WriteLine($"Cannot divide {firstNumber} by zero");
                    }
                    else
                    {
                        Console.WriteLine($"{firstNumber} {operatorSymbol} {secondNumber} = {firstNumber % secondNumber}");
                    }
                    break;

                default:
                    break;
            }

        }
    }
}
