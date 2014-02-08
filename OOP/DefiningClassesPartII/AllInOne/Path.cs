//4. Create a class Path to hold a sequence of points in the 3D space. Create a static class PathStorage with static methods to save and load paths from a text file. Use a file format of your choice.

using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace AllInOne
{
    internal class Path 
    {
        private List<Point3D> list = new List<Point3D>();
        
        internal void AddPoint(Point3D point3D)
        {
            this.list.Add(point3D);
        }

        internal string this[int index]
        {
            get
            {
                return this.list[index].ToString();
            }
        }



        public int Length { get { return this.list.Count; } }
    }

    internal static class PathStorage
    {
        internal static Path Load(string fileName)
        {
            Path result = new Path();

            StreamReader reader = new StreamReader(fileName);

            using (reader)
            {
                while (reader.EndOfStream != true)
                {
                    string[] tokens = reader.ReadLine().Split(',');

                    result.AddPoint(new Point3D(int.Parse(tokens[0]), int.Parse(tokens[1]), int.Parse(tokens[2])));
                }
            }
            return result;
        }

        internal static void Save(Path path, string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);

            using (writer)
            {

                for (int i = 0; i < path.Length; i++)
			{
			 
			   writer.WriteLine(path[i]);
                }
                //while (reader.EndOfStream != true)
                //{
                //    string[] tokens = reader.ReadLine().Split(',');

                //    result.AddPoint(new Point3D(int.Parse(tokens[0]), int.Parse(tokens[1]), int.Parse(tokens[2])));
                //}
            }
        }
    }
}
