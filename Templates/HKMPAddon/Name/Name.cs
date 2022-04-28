using Hkmp.Api.Client;
using Hkmp.Api.Server;
using Modding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using {name}.HKMP;

using UObject = UnityEngine.Object;

namespace {name}
{
    internal class {name} : Mod
    {
        internal static {name} Instance { get; private set; }

        /// <summary>
        /// An instance of the client add-on class.
        /// </summary>
        private static readonly {name}ClientAddon _clientAddon = new();
        
        /// <summary>
        /// An instance of the server add-on class.
        /// </summary>
        private static readonly {name}ServerAddon _serverAddon = new();

        public {name}() : base("{name}") { }

        public override string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public override void Initialize()
        {
            Log("Initializing");

            Instance = this;

            // Register the client and server add-ons.
            ClientAddon.RegisterAddon(_clientAddon);
            ServerAddon.RegisterAddon(_serverAddon);

            Log("Initialized");
        }
    }
}