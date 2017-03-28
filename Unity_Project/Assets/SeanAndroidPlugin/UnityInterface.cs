using UnityEngine;
using UnityEngine.Events;

namespace SeanAndroidPlugin
{
    public class UnityInterface : MonoBehaviour
    {
        //Use this class as your means of interacting with the plugin to ensure compatibility.

        public PermissionGranter_Android Granter;

        public event UnityAction<bool> CompatibiltyCallback;

        public void Ask()
        {
            var success = IsCompatible();

            if (success)
            {
                RequestCameraPermission();
            }

            OnCompatibiltyCallback(success);
        }

        private static bool IsCompatible()
        {
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

        private void RequestContactsPermission_Read()
        {
            if (Granter == null)
                Granter = new PermissionGranter_Android();

            Granter.AskForContactsPermission_Read();
        }

        private void RequestContactsPermission_Write()
        {
            if (Granter == null)
                Granter = new PermissionGranter_Android();

            Granter.AskForContactsPermission_Write();
        }

        private void RequestStoragePermission_Read()
        {
            if (Granter == null)
                Granter = new PermissionGranter_Android();

            Granter.AskForStoragePermission_Read();
        }

        private void RequestStoragePermission_Write()
        {
            if (Granter == null)
                Granter = new PermissionGranter_Android();

            Granter.AskForStoragePermission_Write();
        }


        protected virtual void OnCompatibiltyCallback(bool arg0)
        {
            if (CompatibiltyCallback != null)
            {
                CompatibiltyCallback(arg0);
            }
        }
    }
}
