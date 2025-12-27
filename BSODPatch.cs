using Hacknet;
using HarmonyLib;
using Pathfinder.Action;
using Pathfinder.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using Hacknet.Effects;
using Hacknet.Extensions;
using Hacknet.Factions;
using Hacknet.Gui;
using Hacknet.Localization;
using Hacknet.Misc;
using Hacknet.Mission;
using Hacknet.Modules.Overlays;
using Hacknet.PlatformAPI.Storage;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Module = Hacknet.Module;

namespace Schizo;
[HarmonyPatch(typeof(CrashModule), nameof(CrashModule.LoadContent))]
public class BSODPatch
{
    static void Postfix(CrashModule __instance)
    {
        CrashModule.beep = __instance.os.content.Load<SoundEffect>("SFX/beep");
        char[] array = new char[]
        {
            '\n'
        };
        string text = "Content/";
        if (Settings.IsInExtensionMode)
        {
            text = ExtensionLoader.ActiveExtensionInfo.FolderPath + "/";
        }
        StreamReader streamReader;
        if (File.Exists(text + "BSOD.txt"))
        {
            streamReader = new StreamReader(TitleContainer.OpenStream(text + "BSOD.txt"));
        }
        else
        {
            streamReader = new StreamReader(TitleContainer.OpenStream( "Content/BSOD.txt"));
        }
        __instance.bsodText = streamReader.ReadToEnd();
        streamReader.Close();
        if (File.Exists(text + "BSODBGColor.txt"))
        {
            streamReader = new StreamReader(TitleContainer.OpenStream(text + "BSODBGColor.txt"));
        }
        else
        {
            streamReader = new StreamReader(TitleContainer.OpenStream( "Content/BSODBGColor.txt"));
        }
        __instance.bluescreenBlue = Utils.convertStringToColor(streamReader.ReadToEnd());
        streamReader.Close();
        if (File.Exists(text + "BSODColorFont.txt"))
        {
            streamReader = new StreamReader(TitleContainer.OpenStream(text + "BSODColorFont.txt"));
        }
        else
        {
            streamReader = new StreamReader(TitleContainer.OpenStream( "Content/BSODColorFont.txt"));
        }
        __instance.textColor = Utils.convertStringToColor(streamReader.ReadToEnd());
        streamReader.Close();
        if (File.Exists(text + "BSODFont.txt"))
        {
            streamReader = new StreamReader(TitleContainer.OpenStream(text + "BSODFont.txt"));
        }
        else
        {
            streamReader = new StreamReader(TitleContainer.OpenStream( "Content/BSODFont.txt"));
        }
        __instance.bsodFont = __instance.os.ScreenManager.Game.Content.Load<SpriteFont>(streamReader.ReadToEnd());
        streamReader.Close();
        if (File.Exists(text + "OSXBoot.txt"))
        {
            streamReader = new StreamReader(TitleContainer.OpenStream(text + "OSXBoot.txt"));
        }
        else
        {
            streamReader = new StreamReader(TitleContainer.OpenStream( "Content/OSXBoot.txt"));
        }
        __instance.originalBootText = streamReader.ReadToEnd();
        streamReader.Close();
        __instance.loadBootText();
        __instance.bootTextDelay = CrashModule.BOOT_TIME / ((float)(__instance.bootText.Length - 1) * 2f);
        return;
    }
}
[HarmonyPatch(typeof(CrashModule), nameof(CrashModule.checkOSBootFiles))]
public class BootPatch
{
    static bool Prefix(string bootString)
    {
        
        return true;
    }
}
