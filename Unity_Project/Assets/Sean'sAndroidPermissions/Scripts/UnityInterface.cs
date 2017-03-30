using UnityEngine;

namespace SeansAndroidPermissions
{
    //Use this class as your means of interacting with the plugin to ensure compatibility.
#if UNITY_ANDROID
    public class UnityInterface : MonoBehaviour
    {
        private PermissionGranterProxy Granter;

        // Request Codes
        [HideInInspector]
        public int REQUEST_CODE_CAMERA = 1;
        [HideInInspector]
        public int REQUEST_CODE_CONTACTS_READ = 2;
        [HideInInspector]
        public int REQUEST_CODE_CONTACTS_WRITE = 3;
        [HideInInspector]
        public int REQUEST_CODE_STORAGE_READ = 4;
        [HideInInspector]
        public int REQUEST_CODE_STORAGE_WRITE = 5;
        [HideInInspector]
        public int REQUEST_CODE_LOCATION_FINE = 6;
        [HideInInspector]
        public int REQUEST_CODE_LOCATION_COARSE = 7;

        // Check a permission status of requestCode
        public bool CheckPermissions(int requestCode)
        {
            if (!IsCompatible())
                return false;

            if (Granter == null)
                Granter = new PermissionGranterProxy();

            return Granter.CheckForPermission(requestCode);
        }

        // Request a permission of requestCode
        public void RequestPermission(int requestCode)
        {
            if (!IsCompatible())
                return;

            if (Granter == null)
                Granter = new PermissionGranterProxy();

            Granter.RequestPermission(requestCode);
        }

        // This is the callback from Requesting a permission.
        // 'message' will either return as 'Granted' or 'Denied' after calling Ask.
        public void PermissionCallback(string result)
        {
            if (result == "Granted")
            {
                // Permission was granted.
            }
            else if (result == "Denied")
            {
                // Permission was denied.
            }
        }

        // Runtime permission granting is only accesible from devices with API 23 and up.
        // You should already be performing this check on your own.
        public bool IsCompatible()
        {
            if (Granter == null)
                Granter = new PermissionGranterProxy();

            var versionNumber = Granter.GetSdkVersion();

            return versionNumber >= 23;
        }

        // Retrieve the SDK version number of the device.], from the API.
        public int GetSdkVersion()
        {
            if (Granter == null)
                Granter = new PermissionGranterProxy();

            return Granter.GetSdkVersion();
        }
    }
#endif
}
