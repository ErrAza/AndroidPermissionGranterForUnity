using UnityEngine;

namespace SeanAndroidPlugin
{
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

        public void AskForContactsPermission_Read()
        {
            if (_class == null)
            {
                Initialize();
            }

            Instance.Call("requestContactsPermissionRead");
        }

        public void AskForContactsPermission_Write()
        {
            if (_class == null)
            {
                Initialize();
            }

            Instance.Call("requestContactsPermissionWrite");
        }

        public void AskForStoragePermission_Read()
        {
            if (_class == null)
            {
                Initialize();
            }

            Instance.Call("requestStoragePermissionRead");
        }

        public void AskForStoragePermission_Write()
        {
            if (_class == null)
            {
                Initialize();
            }

            Instance.Call("requestStoragePermissionWrite");
        }

    }
}
