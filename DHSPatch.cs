namespace Schizo;

using HarmonyLib;
using Hacknet;

[HarmonyPatch(typeof(DLCHubServer), nameof(DLCHubServer.DoLoadingPlayerInScreen))]
public class NoWooshPatch
{
    static void Prefix(DLCHubServer __instance)
    {
        __instance.HasStartedWoosh = true;
    }
}
