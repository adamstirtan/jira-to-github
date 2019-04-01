using System;
using System.Threading.Tasks;

using Octokit;

namespace jiratogithub
{
    public class GithubImporter
    {
        private const string GitHubUserName = "";
        private const string GitHubPassword = "";

        private readonly GitHubClient _client;
        private readonly string _repositoryName;
        private readonly string _repositoryOwner;

        private long _repositoryId;

        public GithubImporter(
            string repositoryName,
            string repositoryOwner)
        {
            _repositoryName = repositoryName;
            _repositoryOwner = repositoryOwner;

            _client = new GitHubClient(new ProductHeaderValue("jiratogithub"))
            {
                Credentials = new Credentials(GitHubUserName, GitHubPassword)
            };
        }

        public async Task InitializeAsync()
        {
            var repository = await _client.Repository.Get(_repositoryOwner, _repositoryName);

            _repositoryId = repository.Id;
        }

        public async Task<bool> Import(JiraCase jiraCase)
        {
            try
            {
                var issue = await _client.Issue.Create(_repositoryId, new NewIssue(jiraCase.Summary)
                {
                    Body = jiraCase.Description
                });

                var updateIssue = issue.ToUpdate();

                updateIssue.AddLabel("JIRA");

                await _client.Issue.Update(_repositoryId, issue.Number, updateIssue);

                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }
    }
}