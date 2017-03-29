using System.Collections;
using System.Collections.Generic;
using SeansAndroidPermissions;
using UnityEngine;

public class Test : MonoBehaviour
{

    public UnityInterface obj;

    public void Ask1()
    {
        obj.RequestCameraPermission();
    }

    public void Ask2()
    {
        obj.RequestContactsPermission(UnityInterface.Role.Read);
    }

    public void Ask3()
    {
        obj.RequestContactsPermission(UnityInterface.Role.Write);
    }

    public void Ask4()
    {
        obj.RequestStoragePermission(UnityInterface.Role.Read);
    }

    public void Ask5()
    {
        obj.RequestStoragePermission(UnityInterface.Role.Write);
    }

    public void Ask6()
    {
        obj.RequestLocationPermission(UnityInterface.Accuracy.Fine);
    }

    public void Ask7()
    {
        obj.RequestLocationPermission(UnityInterface.Accuracy.Coarse);
    }

}
