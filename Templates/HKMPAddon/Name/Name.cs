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
        private {name}ClientAddon _clientAddon;
        
        /// <summary>
        /// An instance of the server add-on class.
        /// </summary>
        private {name}ServerAddon _serverAddon;

        public {name}() : base("{name}") { }

        public override string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public override void Initialize()
        {
            Log("Initializing");

            Instance = this;

            _clientAddon = new {name}ClientAddon();
            _serverAddon = new {name}ServerAddon();

            // Register the client and server add-ons.
            ClientAddon.RegisterAddon(_clientAddon);
            ServerAddon.RegisterAddon(_serverAddon);

            Log("Initialized");
        }
    }
}