using Octokit;

namespace Contributers.API
{
    public class GitHubService
    {
        private readonly IGitHubClient _gitHubClient;

        public GitHubService(IGitHubClient gitHubClient)
        {
            _gitHubClient = gitHubClient;
        }

        public async Task<IEnumerable<Committer>> GetContributers(string username, string repository)
        {
            var commits = await _gitHubClient.Repository.Commit.GetAll(username, repository, new ApiOptions { PageCount = 1, PageSize = 30 });

            return commits.Select(c => c.Commit.Author);
        }
    }
}
