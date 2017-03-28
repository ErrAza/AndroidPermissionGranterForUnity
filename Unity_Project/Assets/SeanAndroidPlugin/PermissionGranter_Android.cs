using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

namespace SeanAndroidPlugin
{
    // I would highly recommend NOT modifying anything in here, as this is specifically built to act as the middleman between Unity and Android. Java and C# Proxy.

    public class PermissionGranter_Android
    {
        private AndroidJavaClass _class;
        AndroidJavaObject Instance { get { return _class.GetStatic<AndroidJavaObject>("instance"); } }

        public void Initialize()
        {
            _class = new AndroidJavaClass("com.seanix.sean.plugin.PermissionGranter");
            _class.CallStatic("start", "Granter");
        }

        public void AskForCameraPermission()
        {
            if (_class == null)
            {
                Initialize();
            }

            Instance.Call("requestCameraPermission");
        }

    }
}
