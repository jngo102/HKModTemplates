using Hkmp.Api.Client;
using Hkmp.Api.Server;
using Modding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using {modName}.HKMP;

using UObject = UnityEngine.Object;

namespace {modName}
{
    internal class {modName} : Mod
    {
        internal static {modName} Instance { get; private set; }

        private static readonly {modName}ClientAddon _clientAddon = new();
        private static readonly {modName}ServerAddon _serverAddon = new();

        public {modName}() : base("{modName}") { }

        public override string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public override void Initialize()
        {
            Log("Initializing");

            Instance = this;

            ClientAddon.RegisterAddon(_clientAddon);
            ServerAddon.RegisterAddon(_serverAddon);

            Log("Initialized");
        }
    }
}