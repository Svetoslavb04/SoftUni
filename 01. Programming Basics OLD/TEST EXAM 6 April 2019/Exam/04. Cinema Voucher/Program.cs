namespace _04._Cinema_Voucher
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var voucher = int.Parse(Console.ReadLine());

            int tickets = 0;
            int otherPurchases = 0;

            while (true)
            {
                var purchase = Console.ReadLine();

                if (purchase == "End")
                {
                    break;
                }

                if (purchase.Length > 8)
                {
                    voucher -= (int)purchase[0] + (int)purchase[1];
                    if (voucher < 0)
                    {
                        break;
                    }
                    tickets++;
                }
                else
                {
                    voucher -= (int)purchase[0];
                    if (voucher < 0)
                    {
                        break;
                    }
                    otherPurchases++;
                }
            }

            Console.WriteLine(tickets);
            Console.WriteLine(otherPurchases);
        }
    }
}
