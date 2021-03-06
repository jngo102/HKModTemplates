using Modding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace {name}
{
    internal class {name} : Mod, IGlobalSettings<GlobalSettings>, ILocalSettings<LocalSettings>
    {
        internal static {name} Instance { get; private set; }

        public GlobalSettings GlobalSettings { get; private set; } = new();
        public LocalSettings LocalSettings { get; private set; } = new();

        public {name}(): base("{name}") { }

        public override string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public override void Initialize()
        {
            Log("Initializing");

            Instance = this;

            Log("Initialized");
        }

        public void OnLoadGlobal(GlobalSettings globalSettings)
        {
            GlobalSettings = globalSettings;
        }

        public GlobalSettings OnSaveGlobal()
        {
            return GlobalSettings;
        }

        public void OnLoadLocal(LocalSettings localSettings)
        {
            LocalSettings = localSettings;
        }

        public LocalSettings OnSaveLocal()
        {
            return LocalSettings;
        }
    }
}