using System;
using System.Collections.Generic;
using System.Text;

namespace _07.FoodShortage
{
    interface IBuyer
    {
        int Food { get; set; }
        string Name { get; set; }

        void BuyFood();
    }
}
