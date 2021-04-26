namespace DB
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database
    {
        private int[] database;
        private int index;

        public Database(params int[] integers)
        {
            if (integers.Length > 16)
            {
                throw new InvalidOperationException();
            }

            this.database = new int[16];
            this.index = integers.Length;

            Array.Copy(integers, database, index);
        }

        public void Add(int integer)
        {
            if (index == 16)
            {
                throw new InvalidOperationException("Array cannot be more than 16 cells");
            }

            this.database[index++] = integer;
        }

        public void Remove()
        {
            if (index == 0)
            {
                throw new InvalidOperationException();
            }

            int[] newData = new int[index - 1];

            for (int i = 0; i < index - 1; i++)
            {
                newData[i] = this.database[i];
            }

            this.database = newData;
        }

        public int[] Fetch()
        {
            
            return this.database.Take(index).ToArray();
        }
    }
}
