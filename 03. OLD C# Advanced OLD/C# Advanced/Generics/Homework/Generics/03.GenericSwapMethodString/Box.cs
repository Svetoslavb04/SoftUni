using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodString
{
    class Box<T>
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return $"{value.GetType()}: {value}";
        }
    }
}
