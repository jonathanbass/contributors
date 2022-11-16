using Contributers.API.Queries;
using MediatR;
using Octokit;

namespace Contributers.API.Handlers
{
    public class GetContributorsHandler : IRequestHandler<GetContributersQuery, IEnumerable<Committer>>
    {
        private readonly GitHubService _gitHubService;

        public GetContributorsHandler(GitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        public async Task<IEnumerable<Committer>> Handle(GetContributersQuery request, CancellationToken cancellationToken)
        {
            var response = await _gitHubService.GetContributers(request.username, request.repository);
            return response.Contributers;
        }
    }
}
