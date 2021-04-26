namespace SoftUniRestaurant.Models.Tables.Contracts
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;

    public interface ITable
    {
        int TableNumber { get; }
        int Capacity { get; }
        bool IsReserved { get; }
        decimal Price { get; }

        decimal GetBill();
        string GetFreeTableInfo();
        string GetOccupiedTableInfo();
        void Reserve(int numberOfPeople);
        void OrderFood(IFood food);
        void OrderDrink(IDrink drink);
        void Clear();
    }
}
