using System.Threading.Tasks;

using Octokit;

namespace jiratogithub
{
    public class GithubImporter
    {
        private const string GitHubUserName = "";
        private const string GitHubPassword = "";

        private readonly string _repositoryName;
        private readonly string _repositoryOwner;
        private readonly GitHubClient _client;

        public GithubImporter(
            string repositoryName,
            string repositoryOwner)
        {
            _repositoryName = repositoryName;
            _repositoryOwner = repositoryOwner;

            var basicAuth = new Credentials(GitHubUserName, GitHubPassword);

            _client = new GitHubClient(new ProductHeaderValue("fernjiraimporter"));
            _client.Credentials = basicAuth;
        }

        public async Task<bool> Import(JiraCase jiraCase)
        {
            var createIssue = new NewIssue(jiraCase.Summary);

            createIssue.Body = jiraCase.GetBody();

            var issue = await _client.Issue.Create(
                _repositoryOwner,
                _repositoryName,
                createIssue);

            return issue.State == ItemState.Open;
        }
    }
}