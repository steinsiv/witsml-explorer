using WitsmlExplorer.Api.Jobs.Common;

namespace WitsmlExplorer.Api.Jobs
{
    public class CopyMessageObjectJob
    {
        public MessageObjectReference Source { get; set; }
        public WellboreReference Target { get; set; }
    }
}
