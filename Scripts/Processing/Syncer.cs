using System;
using System.IO;
using System.Reflection;
using Utf8Json;

namespace LDtkDefinitionSync
{
    public class Syncer
    {
        //from our app that we are running our ldtk file from
        
        public void Start()
        {
            Assembly entryAsm = Assembly.GetExecutingAssembly();
            Console.WriteLine($"LDtkDefinitionSync version {entryAsm.GetName().Version}");
            
            string dir = Environment.CurrentDirectory;
            Console.WriteLine($"Working from {dir}");

            /*string[] args = Environment.GetCommandLineArgs();
            if (args.IsNullOrEmpty() || args.Length < 2)
            {
                Console.WriteLine("Didn't operate any files. No second arg! There needs to be a project file name arg in the command.");
                Console.Read();
                return;
            }*/
            
            //string exePath = args[0];
            //string fileName = args[1];
            
            //string projectPath = Path.Combine(dir, fileName) + ".ldtk";

            /*if (!File.Exists(projectPath))
            {
                Console.WriteLine($"This project doesn't exist!\n\"{projectPath}\"\nDouble check that your file name is accurate and fix it if needed.");
                Console.Read();
                return;
            }*/
            
            //Console.WriteLine($"Got file! {projectPath}");
            //ProcessProject(projectPath);
        }
        
        public void ProcessProject(string projectPath)
        {
            LdtkJson json = null;
            
            Profiler.RunWithProfiling("Deserialize Project", () =>
            {
                byte[] bytes = File.ReadAllBytes(projectPath);
                json = JsonSerializer.Deserialize<LdtkJson>(bytes);
            });

            
        }
    }
}