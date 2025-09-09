using Pathfinder.Action;
using Pathfinder.Util;
using Hacknet;
using System;

namespace Schizo;

public class ScreenGlitch : DelayablePathfinderAction
{
    [XMLStorage] public string Enabled;
    [XMLStorage] public float Intensity;
    [XMLStorage] public float GDelay;

    public static bool sEnabled = false;
    public static float sIntensity = 12;
    public static float sDelay = 0f;

    public override void Trigger(OS os)
    {
        sEnabled = Enabled == "true";
        sIntensity = Intensity;
        sDelay = GDelay;
        //Hacknet.PostProcessor.EndingSequenceFlashOutActive = true;
    }
}