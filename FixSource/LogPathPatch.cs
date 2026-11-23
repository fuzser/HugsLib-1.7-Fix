using System.IO;
using HarmonyLib;
using HugsLib.Utils;
using UnityEngine;
using Verse;

namespace HugsLibFixFor17;

[StaticConstructorOnStartup]
public static class LogPathPatch
{
    static LogPathPatch()
    {
        new Harmony("worldleader.hugslib.1.7.fix").PatchAll(typeof(LogPathPatch).Assembly);
    }

    [HarmonyPatch(typeof(HugsLibUtility), nameof(HugsLibUtility.TryGetLogFilePath))]
    [HarmonyPostfix]
    private static void UseWaylithLogDirectory(ref string __result)
    {
        if (!string.IsNullOrEmpty(__result) && File.Exists(__result))
        {
            return;
        }

        string persistentDataPath = Application.persistentDataPath;
        if (string.IsNullOrEmpty(persistentDataPath))
        {
            return;
        }

        string waylithLog = Path.Combine(persistentDataPath, "Logs", "Player.log");
        if (File.Exists(waylithLog))
        {
            __result = waylithLog;
        }
    }
}
