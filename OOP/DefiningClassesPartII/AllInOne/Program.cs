using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne
{

    class Program
    {
        static void Main(string[] args)
        {
            //Calc.Distance()
            Console.WriteLine(Point3D.O());
            Path test = PathStorage.Load("..\\..\\PathLoad.txt");
            PathStorage.Save(test, "..\\..\\PathSave.txt");
        }
    }
}
