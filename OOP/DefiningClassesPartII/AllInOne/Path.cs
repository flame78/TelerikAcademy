//4. Create a class Path to hold a sequence of points in the 3D space. Create a static class PathStorage with static methods to save and load paths from a text file. Use a file format of your choice.

using System.Collections.Generic;
namespace AllInOne
{
    private class Path
    {
        private List<Point3D> list = new List<Point3D>();
    }

    private static class PathStorage
    {
        private static void Load(Path path, string fileName)
        {

        }

        private static void Save(Path path, string fileName)
        {

        }
    }
}
