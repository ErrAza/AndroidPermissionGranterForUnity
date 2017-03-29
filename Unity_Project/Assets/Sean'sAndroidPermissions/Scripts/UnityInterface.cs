using UnityEngine;

namespace SeansAndroidPermissions
{
    //Use this class as your means of interacting with the plugin to ensure compatibility.
#if UNITY_ANDROID
    public class UnityInterface : MonoBehaviour
    {
        private PermissionGranterProxy Granter;

        public enum Role
        {
            Read = 0,
            Write = 1
        }

        public enum Accuracy
        {
            Fine = 0,
            Coarse = 1
        }

        // This is the callback from Requesting a permission.
        // 'message' will either return as 'Granted' or 'Denied' after calling Ask.
        public void PermissionCallback(string message)
        {
            if (message.Contains("Granted"))
            {
                // Do something.
            }
            else if (message.Contains("Denied"))
            {
                // Do something.
            }
        }

        public void RequestCameraPermission()
        {
            if (!IsCompatible())
                return;

            if (Granter == null)
                Granter = new PermissionGranterProxy();

            Granter.AskForCameraPermission();
        }

        public void RequestContactsPermission(Role role)
        {
            if (!IsCompatible())
                return;

            if (Granter == null)
                Granter = new PermissionGranterProxy();

            switch (role)
            {
                case Role.Read:
                    Granter.AskForContactsReadPermission();
                    break;
                case Role.Write:
                    Granter.AskForContactsWritePermission();
                    break;
            }
        }

        public void RequestStoragePermission(Role role)
        {
            if (!IsCompatible())
                return;

            if (Granter == null)
                Granter = new PermissionGranterProxy();

            switch (role)
            {
                case Role.Read:
                    Granter.AskForStorageReadPermission();
                    break;
                case Role.Write:
                    Granter.AskForStorageWritePermission();
                    break;
            }
        }

        public void RequestLocationPermission(Accuracy accuracy)
        {
            if (!IsCompatible())
                return;

            if (Granter == null)
                Granter = new PermissionGranterProxy();

            switch (accuracy)
            {
                case Accuracy.Fine:
                    Granter.AskForLocationFinePermission();
                    break;
                case Accuracy.Coarse:
                    Granter.AskForLocationCoarsePermission();
                    break;
            }
        }

        public static bool IsCompatible()
        {
            // Runtime permission granting is only accesible from devices with API 23 and up.

            var os = SystemInfo.operatingSystem;

            bool compatible;

            if (os.Contains("API-25"))
            {
                compatible = true;
            }
            else if (os.Contains("API-24"))
            {
                compatible = true;
            }
            else if (os.Contains("API-23"))
            {
                compatible = true;
            }
            else
            {
                compatible = false;
            }

            return compatible;
        }
    }
#endif
}
