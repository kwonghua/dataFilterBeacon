// Kevin Wong-hua
// IBeacon.cs
// Used for beacon.cs class

using System;
using System.Collections.Generic;
using System.Text;

namespace _32_P3
{
    public interface IBeacon
    {
        int getSignal();
        bool switchPower();

        void charge();

        bool isActive();
    }
}
