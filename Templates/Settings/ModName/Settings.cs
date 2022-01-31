using System;

namespace {modName}
{
    [Serializable]
    // Global settings persist across all save files.
    public class GlobalSettings
    {
        // public int myGlobalSetting = 5;
    }

    [Serializable]
    // Local settings are unique within each save file.
    public class LocalSettings
    {
        // public bool myLocalSetting = true;
    }
}