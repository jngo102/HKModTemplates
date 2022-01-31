using Modding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace {modName}
{
    public class {modName} : Mod, IGlobalSettings<GlobalSettings>, ILocalSettings<LocalSettings>
    {
        private GlobalSettings _globalSettings = new();
        private LocalSettings _localSettings = new();

        public GlobalSettings GlobalSettings => _globalSettings;
        public LocalSettings LocalSettings => _localSettings;

        internal static {modName} Instance;

        public override void Initialize()
        {
            Log("Initializing");

            Instance = this;

            Log("Initialized");
        }

        public void OnLoadGlobal(GlobalSettings globalSettings)
        {
            _globalSettings = globalSettings;
        }

        public GlobalSettings OnSaveGlobal()
        {
            return _globalSettings;
        }

        public void OnLoadLocal(LocalSettings localSettings)
        {
            _localSettings = localSettings;
        }

        public LocalSettings OnSaveLocal()
        {
            return _localSettings;
        }
    }
}