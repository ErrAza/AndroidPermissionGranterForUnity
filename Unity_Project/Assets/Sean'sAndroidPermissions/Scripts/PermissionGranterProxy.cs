using UnityEngine;

namespace SeansAndroidPermissions
{
    // I would highly recommend NOT modifying anything in here, as this is specifically built to act as the middleman between Unity and Android. Java and C# Proxy.
#if UNITY_ANDROID
    public class PermissionGranterProxy
    {
        private AndroidJavaClass _class;
        AndroidJavaObject Instance { get { return _class.GetStatic<AndroidJavaObject>("instance"); } }

        public void Initialize()
        {
            _class = new AndroidJavaClass("com.seanix.sean.plugin.PermissionGranter");
            _class.CallStatic("start", "Granter");
        }

        public bool CheckForPermission(int requestCode)
        {
            if (_class == null)
            {
                Initialize();
            }

            return Instance.Call<bool>("checkPermission", requestCode);
        }

        public void RequestPermission(int requestCode)
        {
            if (_class == null)
            {
                Initialize();
            }

            Instance.Call("requestPermission", requestCode);
        }

        public int GetSdkVersion()
        {
            if (_class == null)
            {
                Initialize();
            }

            return Instance.Call<int>("getSdkVersion");
        }
    }
#endif
}
