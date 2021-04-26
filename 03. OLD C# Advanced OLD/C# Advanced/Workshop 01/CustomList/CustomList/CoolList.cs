using System;

namespace CustomList
{
    public class CoolList
    {
        private const int InitialCapacity = 2;
        private int[] items;

        public CoolList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.items[index];
            }

            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.items[index] = value;
            }
        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        public void Add(int item)
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        public int RemoveAt(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int item = this.items[index];

            this.items[index] = default(int);
            Shift(index);

            Count--;

            if (Count <= this.items.Length / 4)
            {
                Shrink();
            }

            return item;
        }
    }
}
