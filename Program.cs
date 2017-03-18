using System.Diagnostics;
using System.IO;

namespace FileVer2Txt
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
                return;
            var assFile = args[0];
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assFile);
            File.WriteAllText("version.txt", fvi.FileVersion);
        }
    }
}
