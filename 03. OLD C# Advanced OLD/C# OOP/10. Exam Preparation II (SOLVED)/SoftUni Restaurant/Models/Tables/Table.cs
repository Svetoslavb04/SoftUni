namespace SoftUniRestaurant.Models.Tables
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Table : ITable
    {
        private readonly IList<IFood> foodOrders;
        private readonly IList<IDrink> drinkOrders;
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
            this.numberOfPeople = 0;
            this.IsReserved = false;
        }

        public int TableNumber
        {
            get => this.tableNumber;
            private set => this.tableNumber = value;
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get => this.pricePerPerson;
            private set => this.pricePerPerson = value;
        }

        public bool IsReserved
        {
            get => this.isReserved;
            private set => this.isReserved = value;
        }

        public decimal Price => this.foodOrders.Sum(x => x.Price) + this.drinkOrders.Sum(x => x.Price) + this.PricePerPerson * this.NumberOfPeople;

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return this.Price;
        }

        public string GetFreeTableInfo()
        {
            var stringbuilder = new StringBuilder();

            stringbuilder.AppendLine($"Table: {this.TableNumber}");
            stringbuilder.AppendLine($"Type: {this.GetType().Name}");
            stringbuilder.AppendLine($"Capacity: {this.Capacity}");
            stringbuilder.AppendLine($"Price per Person: {this.PricePerPerson:F2}");

            return stringbuilder.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            var stringbuilder = new StringBuilder();

            stringbuilder.AppendLine($"Table: {this.TableNumber}");
            stringbuilder.AppendLine($"Type: {this.GetType().Name}");
            stringbuilder.AppendLine($"Number of people: {this.NumberOfPeople}");

            if (this.foodOrders.Count == 0)
            {
                stringbuilder.AppendLine("Food orders: None");
            }
            else
            {
                stringbuilder.AppendLine($"Food orders: {this.foodOrders.Count}");
            }

            foreach (var food in this.foodOrders)
            {
                stringbuilder.AppendLine($"{food.ToString()}");
            }

            if (this.drinkOrders.Count == 0)
            {
                stringbuilder.AppendLine("Drink orders: None");
            }
            else
            {
                stringbuilder.AppendLine($"Drink orders: {this.drinkOrders.Count}");
            }

            foreach (var drink in this.drinkOrders)
            {
                stringbuilder.AppendLine($"{drink.ToString()}");
            }

            return stringbuilder.ToString().Trim();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.isReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}
