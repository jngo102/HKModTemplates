using Hkmp.Api.Client;
using Hkmp.Api.Server;
using Modding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using {addonName}.HKMP;

using UObject = UnityEngine.Object;

namespace {addonName}
{
    internal class {addonName} : Mod
    {
        internal static {addonName} Instance { get; private set; }

        private static readonly {addonName}ClientAddon _clientAddon = new();
        private static readonly {addonName}ServerAddon _serverAddon = new();

        public {addonName}() : base("{addonName}") { }

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