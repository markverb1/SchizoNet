using Hacknet;
using Pathfinder.Action;
using Pathfinder.Util;

namespace Schizo;

public class AddFlag : DelayablePathfinderAction
{
    [XMLStorage] public string Flag;

    public override void Trigger(OS os)
    {
        os.Flags.AddFlag(ComputerLoader.filter(Flag));
    }
}

public class RemoveFlag : DelayablePathfinderAction
{
    [XMLStorage] public string Flag;

    public override void Trigger(OS os)
    {
        os.Flags.RemoveFlag(ComputerLoader.filter(Flag));
    }
}
