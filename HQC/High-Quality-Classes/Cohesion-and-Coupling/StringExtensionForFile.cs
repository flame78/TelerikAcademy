namespace CohesionAndCoupling
{
    using System;

    public static class StringExtensionForFile
    {
        public static string GetFileExtension(this string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot == -1)
            {
                return string.Empty;
            }

            string extension = fileName.Substring(indexOfLastDot + 1);

            return extension;
        }

        public static string GetFileNameWithoutExtension(this string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string extension = fileName.Substring(0, indexOfLastDot);

            return extension;
        }
    }
}
