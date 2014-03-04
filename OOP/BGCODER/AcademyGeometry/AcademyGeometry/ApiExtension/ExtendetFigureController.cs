using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryAPI;

namespace AcademyGeometry.ApiExtension
{
    public class ExtendetFigureController : FigureController
    {
        public override void ExecuteFigureCreationCommand(string[] splitFigString)
        {
            switch (splitFigString[0])
            {
                case "circle":
                    {
                        Vector3D center = Vector3D.Parse(splitFigString[1]);
                        double radius = double.Parse(splitFigString[2]);
                        currentFigure = new Circle(center,radius);
                        break;
                    }
                case "cylinder":
                    {
                        Vector3D baseCyrcleCenter = Vector3D.Parse(splitFigString[1]);
                        Vector3D topCyrcleCenter = Vector3D.Parse(splitFigString[2]);
                        double radius = double.Parse(splitFigString[3]);
                        currentFigure = new Cylinder(baseCyrcleCenter, topCyrcleCenter, radius);
                        break;
                    }
                default:
                    {
                        base.ExecuteFigureCreationCommand(splitFigString);
                        return;
                    }
            }

            this.EndCommandExecuted = false;
        }

        protected override void ExecuteFigureInstanceCommand(string[] splitCommand)
        {
           
            switch (splitCommand[0])
            {
                case "area":
                    {
                        var amFigure = this.currentFigure as IAreaMeasurable;
                        if (amFigure!=null)
                        {
                            Console.WriteLine("{0:F2}",amFigure.GetArea());
                        }
                        else Console.WriteLine("undefined");
                        break;
                    }
                case "volume":
                    {
                        var vmFigure = this.currentFigure as IVolumeMeasurable;
                        if (vmFigure != null)
                        {
                            Console.WriteLine("{0:F2}", vmFigure.GetVolume());
                        }
                        else Console.WriteLine("undefined");
                        break;
                    }

                case "normal":
                    {
                        var fFigure = this.currentFigure as IFlat;
                        if (fFigure != null)
                        {
                            Console.WriteLine(fFigure.GetNormal().ToString());
                        }
                        else Console.WriteLine("undefined");
                        break;
                    }
                default:
                    {
                        base.ExecuteFigureInstanceCommand(splitCommand);
                        break;
                    }
                    
            }
        }
    }
}
