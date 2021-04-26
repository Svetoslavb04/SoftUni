namespace PersonInfo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
    }
}
