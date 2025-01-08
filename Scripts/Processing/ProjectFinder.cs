using System.Collections.Generic;
using System.IO;
using Utf8Json;

namespace LDtkDefinitionSync
{
    public class ProjectFinder
    {
        public List<LDtkProject> FindProjects(string searchDir)
        {
            var projects = new List<LDtkProject>();
            var files = Directory.GetFiles(searchDir, "*.ldtk", SearchOption.AllDirectories);
            
            foreach (var file in files)
            {
                var project = new LDtkProject();
                project.Path = file;
                project.Name = Path.GetFileNameWithoutExtension(file);
                projects.Add(project);
            }

            foreach (LDtkProject project in projects)
            {
                Profiler.RunWithProfiling($"Deserialize {project.Name}", () =>
                {
                    byte[] bytes = File.ReadAllBytes(project.Path);
                    project.Json = JsonSerializer.Deserialize<LdtkJson>(bytes);
                });
            }

            return projects;
            
        }
    }
}