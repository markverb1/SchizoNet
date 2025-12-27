using Pathfinder.Action;
using Pathfinder.Util;
using Hacknet;
using System;
using Hacknet.Effects;

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
        sEnabled = Enabled.ToLower() == "true";
        if (sEnabled) FlickeringTextEffect.internalTimer = 0; 
        sIntensity = Intensity > 0 ? Intensity : sIntensity;
        sDelay = GDelay > 0 ? GDelay : sDelay;
        
        //Hacknet.PostProcessor.EndingSequenceFlashOutActive = true;
    }
}