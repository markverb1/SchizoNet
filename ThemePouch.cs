using Hacknet;
using Hacknet.Extensions;
using HarmonyLib;

namespace Schizo;

[HarmonyPatch(typeof(ThemeManager), nameof(ThemeManager.loadThemeBackground))]
public class ThemePouch
{
    public static void Postfix(OS os, OSTheme theme)
    {
        string text = "Content/";
        if (!Settings.IsInExtensionMode)
        {
            return;
        }
        text = ExtensionLoader.ActiveExtensionInfo.FolderPath + "/";
        if (!File.Exists(text + "Themes/Backgrounds/Terminal.png"))
        {
            return;
        }
        if (theme == OSTheme.TerminalOnlyBlack)
        {
            ThemeManager.loadCustomThemeBackground(os,"Themes/Backgrounds/Terminal.png");
        }
    }
}