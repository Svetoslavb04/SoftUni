using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SoftUniRestaurant.Models.Tables.Factories
{
    public class TableFactory : ITableFactory
    {
        public ITable CreateTable(string type, int tableNumber, int capacity)
        {
            Type tableType = Type.GetType($"SoftUniRestaurant.Models.Tables.{type}");

            var table = Activator.CreateInstance(tableType, new object[] { tableNumber, capacity });

            return (ITable)table;
        }
    }
}
