using System.Diagnostics;
using System.IO;

namespace FileVer2Txt
{
    class Program
    {
        static void Main(string[] args)
        {
            //Usage:  FileVer2Txt [file] [numsegs]
            //        file = exe or dll assembly file to read
            //        numsegs = number of version segments to include
            //                  1 = Major
            //                  2 = Major.Minor
            //                  3 = Major.Minor.Build
            //                  4 = Major.Minor.Build.Rev
            if (args.Length < 1)
                return;
            int numSegs = 4;
            if (args.Length > 1)
            {
                int tempSegs;
                if (int.TryParse(args[1], out tempSegs))
                    numSegs = tempSegs;
            }

            var assFile = args[0];
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assFile);

            string strFileVer = "";
            string[] segs = fvi.FileVersion.Split('.');
            for (int i = 0; i < (segs.Length < numSegs ? segs.Length : numSegs); i++)
            {
                if (i > 0) strFileVer += ".";
                strFileVer += segs[i];
            }
            File.WriteAllText("version.txt", strFileVer);
        }
    }
}
