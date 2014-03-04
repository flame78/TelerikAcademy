using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryAPI;
using AcademyGeometry.ApiExtension;

namespace AcademyGeometry
{
    class Program
    {
        private static FigureController GetFigureController()
        {
            return new ExtendetFigureController();
        }

        static void Main(string[] args)
        {
            var figController = GetFigureController();

            int figCreationsCount = int.Parse(Console.ReadLine());
            int endCommandsCount = 0;

            while (endCommandsCount < figCreationsCount)
            {
                figController.ExecuteCommand(Console.ReadLine());
                if (figController.EndCommandExecuted)
                {
                    endCommandsCount++;
                }
            }
        }
    }
}
