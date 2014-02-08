// 1.Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. Implement the ToString() to enable printing a 3D point.

// 2.Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. Add a static property to return the point O.

namespace AllInOne
{
    struct Point3D
    {
        public int X, Y, Z;
        private static readonly Point3D pointO = new Point3D(0, 0, 0);

        public Point3D(int p1, int p2, int p3)
        {
            this.X = p1;
            this.Y = p2;
            this.Z = p3;
        }

        public static Point3D O()
        {
            return pointO;
        }

        public override string ToString()
        {
            return string.Format(X + ", " + Y + ", " + Z);
        }
    }
}
