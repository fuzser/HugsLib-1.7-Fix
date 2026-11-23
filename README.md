# HugsLib — RimWorld 1.7 Waylith Fix

An independent RimWorld 1.7 compatibility patch for [HugsLib](https://github.com/UnlimitedHugs/RimworldHugsLib) 12.0.0.

- In-game title: **HugsLib - 1.7 Waylith Fix (Continued)**
- Package ID: `UnlimitedHugs.HugsLib` (retained for dependency compatibility)

## Fix

Waylith stores the current log at `Logs/Player.log` below RimWorld's persistent data directory. HugsLib 12.0.0 only checked the former root-level `Player.log`, so **Open log file** and log publishing could fail with `FileNotFoundException`.

The 1.7 compatibility assembly patches `HugsLibUtility.TryGetLogFilePath()` and falls back to `Logs/Player.log` when the original path is missing.

## Installation

Copy the repository folder into the RimWorld `Mods` directory. Enable it as **HugsLib** and keep Harmony enabled. Do not enable the original HugsLib copy at the same time.

## Build

```powershell
dotnet build HugsLib.1.7.Fix.csproj -c Release
```

The `v1.7/Assemblies` directory contains the upstream HugsLib 12.0.0 assembly and the separate `HugsLib.1.7.Fix.dll` compatibility patch.

## Credits and licensing

HugsLib was created by UnlimitedHugs and released into the public domain. The original notice is preserved in [LICENSE.txt](LICENSE.txt). Harmony is by Andreas Pardeike under the MIT license.

---

这是 HugsLib 12.0.0 的 RimWorld 1.7 Waylith 独立兼容修复。旧日志路径不存在时，会自动使用 `Logs/Player.log`。
