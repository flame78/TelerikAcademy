using GeometryAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGeometry.ApiExtension
{
   
    public class Cylinder : Figure, IVolumeMeasurable, IAreaMeasurable
    {
        private double radius;
        public Cylinder(Vector3D baseCyrcleCenter, Vector3D topCyrcleCenter, double radius)
            : base(baseCyrcleCenter, topCyrcleCenter)
        {
            this.radius = radius;
        }

        
        public double GetArea()
        {

            double circumference = 2 * Math.PI * this.radius;
            double h = (this.vertices[0] - this.vertices[1]).Magnitude;
            double circleArea = Math.PI * this.radius * this.radius;
            return circumference * h + 2 * circleArea;
        }

        public override double GetPrimaryMeasure()
        {
            
            return this.GetVolume();
        }

        public double GetVolume()
        {
            double circleArea = Math.PI * this.radius * this.radius;
            double h = (this.vertices[0] - this.vertices[1]).Magnitude;
            return h * circleArea;
        }
    }
}
