using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jiratogithub
{
    internal class Program
    {
        // Repository name
        private static readonly string GitHubRepositoryName = "jiraimport";

        // Organization name
        private static readonly string GitHubRepositoryOwner = "fernsoftware";

        private static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            var exporter = new JiraExporter(new List<string> { "1.csv", "2.csv", "3.csv" });

            var importer = new GithubImporter(GitHubRepositoryName, GitHubRepositoryOwner);
            await importer.InitializeAsync();

            var jiraCases = exporter.Export();

            var unresolved = jiraCases.Where(x => x.Status != "Done");

            Console.WriteLine($"Exported {unresolved.Count()} unresolved cases");

            foreach (var jiraCase in jiraCases)
            {
                await importer.Import(jiraCase);
                Console.Write(".");
            }

            Console.WriteLine("\nFinished import!");
            Console.ReadKey();
        }
    }
}