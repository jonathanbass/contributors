using Contributers.API.Responses;
using Microsoft.Extensions.Options;
using Octokit;

namespace Contributers.API
{
    public class GitHubService
    {
        private readonly IGitHubClient _gitHubClient;

        public GitHubService(IOptions<GitHubCredentials> gitHubCredentials)
        {
            var gitHubClient = new GitHubClient(new ProductHeaderValue("GitHubClient"));
            var basicAuth = new Credentials(gitHubCredentials.Value.Username, gitHubCredentials.Value.Password);
            gitHubClient.Credentials = basicAuth;
            _gitHubClient = gitHubClient;
        }

        public async Task<ContributersResponse> GetContributers(string username, string repository)
        {
            var repo = await _gitHubClient.Repository.Get(username, repository);
            var commits = await _gitHubClient.Repository.Commit.GetAll(repo.Id, new ApiOptions { PageCount = 1, PageSize = 30 });

            return new ContributersResponse { Contributers = commits.Select(c => c.Commit.Author) };
        }
    }
}
