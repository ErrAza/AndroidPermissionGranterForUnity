package com.seanix.sean.plugin;

import android.Manifest;
import android.annotation.TargetApi;
import android.app.Fragment;
import android.content.pm.PackageManager;
import android.os.Bundle;
import com.unity3d.player.UnityPlayer;
import android.support.v4.content.ContextCompat;

/**
 * Created by Sean on 3/28/2017.
 */

@TargetApi(23)
public class PermissionGranter extends Fragment {

    public static final String TAG = "Sean_PermissionGranter";

    public static PermissionGranter instance;

    final private int REQUEST_CODE_CAMERA = 1;
    final private int REQUEST_CODE_CONTACTS_READ = 2;
    final private int REQUEST_CODE_CONTACTS_WRITE = 3;
    final private int REQUEST_CODE_STORAGE_READ = 4;
    final private int REQUEST_CODE_STORAGE_WRITE = 5;
    final private int REQUEST_CODE_LOCATION_FINE = 6;
    final private int REQUEST_CODE_LOCATION_COARSE = 7;

    String gameObjectName;

    public static void start(String gameObjectName)
    {
        instance = new PermissionGranter();
        instance.gameObjectName = gameObjectName;
        UnityPlayer.currentActivity.getFragmentManager().beginTransaction().add(instance, PermissionGranter.TAG).commit();
    }

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setRetainInstance(true);
    }

    public boolean checkPermission(int code)
    {
        String perm = "";

        switch (code)
        {
            case REQUEST_CODE_CAMERA:
                perm = Manifest.permission.CAMERA;
                break;
            case REQUEST_CODE_CONTACTS_READ:
                perm = Manifest.permission.READ_CONTACTS;
                break;
            case REQUEST_CODE_CONTACTS_WRITE:
                perm = Manifest.permission.WRITE_CONTACTS;
                break;
            case REQUEST_CODE_STORAGE_READ:
                perm = Manifest.permission.READ_EXTERNAL_STORAGE;
                break;
            case REQUEST_CODE_STORAGE_WRITE:
                perm = Manifest.permission.WRITE_EXTERNAL_STORAGE;
                break;
            case REQUEST_CODE_LOCATION_FINE:
                perm = Manifest.permission.ACCESS_FINE_LOCATION;
                break;
            case REQUEST_CODE_LOCATION_COARSE:
                perm = Manifest.permission.ACCESS_COARSE_LOCATION;
                break;
            default:
                break;
        }

        int perms = ContextCompat.checkSelfPermission(getContext(), perm);

        return (perms == PackageManager.PERMISSION_GRANTED);
    }

    public void requestPermission(int code)
    {
        String perm = "";

        switch (code)
        {
            case REQUEST_CODE_CAMERA:
                perm = Manifest.permission.CAMERA;
                break;
            case REQUEST_CODE_CONTACTS_READ:
                perm = Manifest.permission.READ_CONTACTS;
                break;
            case REQUEST_CODE_CONTACTS_WRITE:
                perm = Manifest.permission.WRITE_CONTACTS;
                break;
            case REQUEST_CODE_STORAGE_READ:
                perm = Manifest.permission.READ_EXTERNAL_STORAGE;
                break;
            case REQUEST_CODE_STORAGE_WRITE:
                perm = Manifest.permission.WRITE_EXTERNAL_STORAGE;
                break;
            case REQUEST_CODE_LOCATION_FINE:
                perm = Manifest.permission.ACCESS_FINE_LOCATION;
                break;
            case REQUEST_CODE_LOCATION_COARSE:
                perm = Manifest.permission.ACCESS_COARSE_LOCATION;
                break;
            default:
                break;
        }

        requestPermissions(new String[]{perm},
                code);
    }

    @Override
    public void onRequestPermissionsResult(int requestCode, String[] permissions, int[] grantResults) {
        if (grantResults[0] == PackageManager.PERMISSION_GRANTED) {
            UnityPlayer.UnitySendMessage(gameObjectName, "PermissionCallback", "Granted");
        } else {
            UnityPlayer.UnitySendMessage(gameObjectName, "PermissionCallback", "Denied");
        }
    }
}
