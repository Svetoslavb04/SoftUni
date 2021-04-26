namespace 1.GenericBoxOfString
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
    {
        private string value;

        public Box(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return $"{value.GetType()}: {value}";
        }
    }
}
