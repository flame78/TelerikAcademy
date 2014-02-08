using System;

    class test
    {
        static void Main()
        {
            //MySqlTransfer.CreateMyDbTbl("localhost", "root", "toor");
            MySqlTransfer.DatFile("localhost", "test", "tbl", "root", "toor", @"..\..\..\2014-02-04.txt");
        }
    }




