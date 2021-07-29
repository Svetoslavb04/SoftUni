using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public interface ISmartphone
    {
        void Call(string number);
        void Browse(string url);
    }
}
