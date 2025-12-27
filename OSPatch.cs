

using Hacknet;
using HarmonyLib;

namespace Schizo;

[HarmonyPatch(typeof(OS), nameof(OS.LoadContent))]
public class OSPatch
{
    public static void Postfix(OS __instance)
    {
        __instance.terminal.name = "cTerm";
        __instance.netMap.name = "NetGraph";
        __instance.display.name = "CENTRAL_Monitor";
        __instance.ram.name = "uTop";
    }
}