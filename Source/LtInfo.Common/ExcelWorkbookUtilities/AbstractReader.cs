using System;
using System.IO;
using System.Reflection;

namespace LtInfo.Common.ExcelWorkbookUtilities
{
    /// <summary>
    /// A few parts in the ExcelWorkbookUtilities namespace used portions of code from the SimpleOOXML library: https://www.nuget.org/packages/SimpleOOXML/
    ///
    /// This library had a dependency on an older version of DocumentFormat.OpenXml that we do not want to support. The parts from the SimpleOOXML library that we used have been
    /// added to this project directly. This is all related to work done on PF #2056, #2058, and #2061.
    /// </summary>
    public abstract class AbstractReader
    {
        /// <summary>
        /// Returns a memory stream with a copy of a file's contents.
        /// </summary>
        public static MemoryStream StreamFromFile(string path)
        {
            byte[] buffer;

            using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[file.Length];
                file.Read(buffer, 0, (int)file.Length);
                file.Close();
            }

            var memory = new MemoryStream();
            memory.Write(buffer, 0, buffer.Length);

            return memory;
        }

        /// <summary>
        /// Returns a copy of an embedded resource from the project as a memory stream. 
        /// </summary>
        /// <remarks>
        /// Include any folder paths in the filename parameter.
        /// </remarks>
        public static MemoryStream GetEmbeddedResourceStream(string filename)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string name = assembly.GetName().Name;

            //Oddly enough the vb.net compiler ignores the folder name, 
            //so you can only have one eg blank.xlsx in the whole project
            //This is different to the c# behaviour
            filename = filename.Replace("/", ".");
            filename = filename.Replace("\\", "."); //If this looks incorrect make sure the input is escaped correctly
            name += "." + filename;

            Stream stream = assembly.GetManifestResourceStream(name);
            if (stream == null) throw new ArgumentException(string.Format("Embedded resource with path {0} was not found.", filename));

            var buffer = new byte[(int)stream.Length];
            var memStream = new MemoryStream(buffer.Length);

            stream.Position = 0;
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();

            memStream.Write(buffer, 0, buffer.Length);

            return memStream;
        }

        /// <summary>
        /// Returns a copy of a file provided as a memory stream.
        ///</summary>
        public static MemoryStream Copy(string path)
        {
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            if (stream == null) throw new ApplicationException(string.Format("File with path {0} was not found.", path));

            var buffer = new byte[(int)stream.Length];
            var memStream = new MemoryStream(buffer.Length);

            stream.Position = 0;
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();

            memStream.Write(buffer, 0, buffer.Length);

            return memStream;
        }
    }
}