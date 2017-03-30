using UnityEngine;
using UnityEngine.UI;

#if UNITY_ANDROID
using SeansAndroidPermissions;

namespace SeansAndroidPermissions.Example
{
    public class Example : MonoBehaviour
    {
        public UnityInterface Obj;
        public Text SdkText;
        public Text CheckText;

        public void Request()
        {
            Obj.RequestPermission(Obj.REQUEST_CODE_CAMERA);
        }

        public void Check()
        {
            CheckText.text = "Has Permission: " + Obj.CheckPermissions(Obj.REQUEST_CODE_CAMERA).ToString();
        }

        public void CheckSdk()
        {
            SdkText.text = "SDK Version: " + Obj.GetSdkVersion().ToString();
        }
    }
}
#endif
