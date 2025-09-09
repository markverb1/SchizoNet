using System.Reflection;
using BepInEx;
using BepInEx.Hacknet;
using HarmonyLib;

namespace Schizo
{
    [BepInPlugin(ModGUID, ModName, ModVer)]
    public class Schizo : HacknetPlugin
    {
        public const string ModGUID = "com.markverb1.SchizoNet";
        public const string ModName = "SchizoNet";
        public const string ModVer = "1.0.1";

        public override bool Load()
        {
            var i = 0;
            foreach (var type in Assembly.GetExecutingAssembly().DefinedTypes)
            {
                i++;
                if (type.GetCustomAttribute(typeof(HarmonyPatch)) != null && !type.Namespace.Contains(".Compat."))
                {
                    Log.LogDebug("Patching " + type);
                    HarmonyInstance.PatchAll(type);
                }
            }

            Pathfinder.Action.ActionManager.RegisterAction<ScreenGlitch>("ScreenGlitch");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"~- SchizoNet v{ModVer} -~");
            return true;
        }
    }
}