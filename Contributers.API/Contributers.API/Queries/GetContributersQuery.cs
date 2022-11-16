using MediatR;
using Octokit;

namespace Contributers.API.Queries
{
    public record GetContributersQuery(string username, string repository) : IRequest<IEnumerable<Committer>>;
}
