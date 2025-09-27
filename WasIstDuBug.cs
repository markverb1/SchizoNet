using Hacknet;
using Pathfinder.Action;
using Pathfinder.Util;

namespace Schizo;

public class DebugCommandsEnabled : PathfinderCondition
{
    public override bool Check(object os_obj)
    {
        OS os = (OS)os_obj;
        return Settings.debugCommandsEnabled;
        // return true if actions inside condition should be triggered
        // return false otherwise
    }
}