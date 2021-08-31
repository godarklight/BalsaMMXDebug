using System;
using BalsaCore;
using UnityEngine;

namespace BalsaMMXDebug
{
    [BalsaAddon]
    public class Loader
    {
        private static GameObject go;

        [BalsaAddonInit(invokeTime = AddonInvokeTime.MainMenu)]
        public static void BalsaInit()
        {
            if (go == null)
            {
                go = new GameObject();
                BalsaMMXDebugMain ba = go.AddComponent<BalsaMMXDebugMain>();
            }
        }

        //Game exit
        [BalsaAddonFinalize]
        public static void BalsaFinalize()
        {
        }
    }
}
