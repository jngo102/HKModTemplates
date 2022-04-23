﻿using Modding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace {modName}
{
    internal class {modName} : Mod
    {
        internal static {modName} Instance { get; private set; }

        public Dictionary<string, GameObject> GameObjects { get; private set; }

        private Dictionary<string, (string, string)> _preloads = new()
        {
            // ["Wingmould"] = ("White_Palace_18", "White Palace Fly"),
        };

        public {modName}() : base("{modName}") { }

        public override List<(string, string)> GetPreloadNames()
        {
            return _preloads;
        }

        public override string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            Log("Initializing...");

            Instance = this;

            foreach (var (name, (scene, path)) in _preloads)
            {
                GameObjects[name] = preloadedObjects[scene][path];
            }

            Log("Initialized.");
        }
    }
}