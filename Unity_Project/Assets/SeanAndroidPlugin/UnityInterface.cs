using UnityEngine;
using UnityEngine.Events;

namespace SeanAndroidPlugin
{
    public class UnityInterface : MonoBehaviour
    {
        //Use this class as your means of interacting with the plugin to ensure compatibility.
        // Override where necessary

        public PermissionGranter_Android Granter;

        // Main function to request camera permission
        // Check the PermissionCallback for the result.
        public void Ask()
        {
            if (IsCompatible())
            {
                RequestCameraPermission();
            }
        }

        // This is the callback from the java class and function Ask, it specifically fires off this method with a string result from Ask.
        // 'message' will either return as 'Granted' or 'Denied' after calling Ask.
        public void PermissionCallback(string message)
        {
            Debug.Log(message);

            if (message.Contains("Granted"))
            {
                //Sweet, Do Something
            }
            else if (message.Contains("Denied"))
            {
                //User was a moron, Do Something
            }
            else
            {
                // Message is blank or something else, indicating a deeper problem, and thus involving panic. => highly unlikely. Implement  fallback in case, but still highly unlikely.
            }
        }

        private static bool IsCompatible()
        {
            // If its not compatible, don't try, the device OS is too old to even have runtime permission granting.

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

        private void RequestCameraPermission()
        {
            if (Granter == null)
                Granter = new PermissionGranter_Android();

            Granter.AskForCameraPermission();
        }

    }
}
