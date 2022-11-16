using Octokit;

namespace Contributers.API.Responses
{
    public class ContributersResponse
    {
        public IEnumerable<Committer> Contributers { get; set; }
    }
}
