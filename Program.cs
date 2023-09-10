using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Authentication.ExtendedProtection;

namespace OONV_Seminarka
{
class Program
{
    static void Main(string[] args)
    {
        Arena arena = new Arena();
        arena.odstartuj_hru();
    }
}
}