﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_test_keepass
{
    class Program
    {
        static void Main(string[] args)
        {
            //test le logger
            KeepassDB_SYNC.Logger.Write(KeepassDB_SYNC.Type.INFO, "Test log info");
            KeepassDB_SYNC.Logger.Write(KeepassDB_SYNC.Type.DEBUG, "Test log debug");
            KeepassDB_SYNC.Logger.Write(KeepassDB_SYNC.Type.ERROR, "Test log error");
        }
    }
}
