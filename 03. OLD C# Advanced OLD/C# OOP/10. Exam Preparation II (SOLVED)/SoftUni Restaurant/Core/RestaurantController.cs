namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Drinks.Factories;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Foods.Factories;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using SoftUniRestaurant.Models.Tables.Factories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RestaurantController
    {
        private FoodFactory foodFactory;
        private DrinkFactory drinkFactory;
        private TableFactory tableFactory;

        private List<IFood> menu;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome;

        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();

            this.foodFactory = new FoodFactory();
            this.drinkFactory = new DrinkFactory();
            this.tableFactory = new TableFactory();
        }


        public string AddFood(string type, string name, decimal price)
        {

            IFood food = this.foodFactory.CreateFood(type, name, price);
            this.menu.Add(food);
            return $"Added {name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = this.drinkFactory.CreateDrink(type, name, servingSize, brand);
            this.drinks.Add(drink);
            return $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = this.tableFactory.CreateTable(type, tableNumber, capacity);
            this.tables.Add(table);
            return $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable findTable = this.tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);
            if (findTable == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            findTable.Reserve(numberOfPeople);

            return $"Table {findTable.TableNumber} has been reserved for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable findTable = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (findTable == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            IFood findFood = this.menu.FirstOrDefault(x => x.Name == foodName);
            if (findFood == null)
            {
                return $"No {foodName} in the menu";
            }

            findTable.OrderFood(findFood);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable findTable = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (findTable == null)
            {
                return $"Could not find table with {tableNumber}";

            }

            IDrink findDrink = this.drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);
            if (findDrink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            findTable.OrderDrink(findDrink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable leaveTable = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            decimal bill = leaveTable.GetBill();
            this.totalIncome += bill;
            leaveTable.Clear();

            return $"Table: {tableNumber}" + Environment.NewLine +
                   $"Bill: {bill:f2}";

        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var currTable in this.tables.Where(x => x.IsReserved == false))
            {
                sb.AppendLine(currTable.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var currTable in this.tables.Where(x => x.IsReserved == true))
            {
                sb.AppendLine(currTable.GetOccupiedTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {this.totalIncome:f2}lv";
        }
    }
}
