using System.Collections;
using System.Collections.Generic;
using SeansAndroidPermissions;
using UnityEngine;

public class Test : MonoBehaviour
{

    public UnityInterface obj;

    public void Check()
    {
        obj.RequestPermission(obj.REQUEST_CODE_CAMERA);
    }

    public void Request()
    {
        bool test = obj.CheckPermissions(obj.REQUEST_CODE_CAMERA);

        Debug.Log(test + " - " + " Permission");
    }



}
