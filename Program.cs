using System;
using System.Threading.Tasks;

namespace jiratogithub
{
    class Program
    {
        private static string GitHubRepositoryName = "";
        private static string GitHubRepositoryOwner = "";

        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            var exporter = new JiraExporter();
            var importer = new GithubImporter(GitHubRepositoryName, GitHubRepositoryOwner);

            var jiraCases = exporter.Export("JIRA.csv");

            var result = false;

            foreach (JiraCase jiraCase in jiraCases)
            {
                result = await importer.Import(jiraCase);
            }
        }
    }
}
