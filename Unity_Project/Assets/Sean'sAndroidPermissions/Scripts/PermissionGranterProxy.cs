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

        // Requests CAMERA permission.
        public void AskForCameraPermission()
        {
            if (_class == null)
            {
                Initialize();
            }

            Instance.Call("requestCameraPermission");
        }

        // Requests READ_CONTACTS permission.
        public void AskForContactsReadPermission()
        {
            if (_class == null)
            {
                Initialize();
            }

            Instance.Call("requestContactsPermissionRead");
        }

        // Requests WRITE_CONTACTS permission.
        public void AskForContactsWritePermission()
        {
            if (_class == null)
            {
                Initialize();
            }

            Instance.Call("requestContactsPermissionWrite");
        }

        // Requests READ_EXTERNAL_STORAGE permission.
        public void AskForStorageReadPermission()
        {
            if (_class == null)
            {
                Initialize();
            }

            Instance.Call("requestStoragePermissionRead");
        }

        // Requests WRITE_EXTERNAL_STORAGE permission.
        public void AskForStorageWritePermission()
        {
            if (_class == null)
            {
                Initialize();
            }

            Instance.Call("requestStoragePermissionWrite");
        }

        // Requests ACCESS_FINE_LOCATION permission.
        public void AskForLocationFinePermission()
        {
            if (_class == null)
            {
                Initialize();
            }

            Instance.Call("requestLocationFine");
        }

        // Requests ACCESS_COARSE_LOCATION permission.
        public void AskForLocationCoarsePermission()
        {
            if (_class == null)
            {
                Initialize();
            }

            Instance.Call("requestLocationCoarse");
        }
    }
#endif
}
