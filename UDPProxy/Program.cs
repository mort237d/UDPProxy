﻿using System;

namespace UDPProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Proxy proxy = new Proxy();
            proxy.Start();
        }
    }
}
