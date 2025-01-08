using System;
using System.IO;
using System.Linq;

namespace LDtkDefinitionSync
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
#if DEBUG
            //to work from the test dir
            args = Environment.GetCommandLineArgs();
            if (args.Any(p=> p == "RUN_TEST"))
            {
                string newDir = Path.Combine(Environment.CurrentDirectory, "..", "..", "Test");
                string newPath = Path.GetFullPath(newDir).Replace(Environment.CurrentDirectory, "");
                Directory.SetCurrentDirectory(newPath);
            }
#endif

            Profiler.RunWithProfiling("BeginExport", () =>
            {
                new Syncer().Start();
            });
            

#if DEBUG
            Console.Read();
#endif
        }
    }
}