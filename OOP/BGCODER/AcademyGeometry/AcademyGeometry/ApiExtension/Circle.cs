using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryAPI;

namespace AcademyGeometry.ApiExtension
{
    
    public class Circle : Figure, IFlat, IAreaMeasurable
    {
        private double radius;
        public Circle(Vector3D center, double radius)
            : base(center)
        {
            this.radius = radius;
        }

        public Vector3D GetNormal()
        {
            // Жоре, не всички сме любители на геометрията :)

            Vector3D center = this.GetCenter();
            Vector3D A = new Vector3D(center.X + this.radius, center.Y, center.Z),
                B = new Vector3D(center.X, center.Y + this.radius, center.Z);

            Vector3D normal = Vector3D.CrossProduct(center - A, center - B);
            normal.Normalize();
            return normal;
        }

        public double GetArea()
        {
            return Math.PI * this.radius * this.radius;
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetArea();
        }
    }
}
