package com.seanix.sean.plugin;

import android.Manifest;
import android.annotation.TargetApi;
import android.app.Fragment;
import android.content.pm.PackageManager;
import android.os.Bundle;
import com.unity3d.player.UnityPlayer;
import android.widget.Toast;

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

    public void requestCameraPermission()
    {
        requestPermissions(new String[]{Manifest.permission.CAMERA},
                REQUEST_CODE_CAMERA);
    }

    public void requestContactsPermissionRead()
    {
        requestPermissions(new String[]{Manifest.permission.READ_CONTACTS},
                REQUEST_CODE_CONTACTS_READ);
    }

    public void requestContactsPermissionWrite()
    {
        requestPermissions(new String[]{Manifest.permission.WRITE_CONTACTS},
                REQUEST_CODE_CONTACTS_WRITE);
    }

    public void requestStoragePermissionRead()
    {
        requestPermissions(new String[]{Manifest.permission.READ_EXTERNAL_STORAGE},
                REQUEST_CODE_STORAGE_READ);
    }

    public void requestStoragePermissionWrite()
    {
        requestPermissions(new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE},
                REQUEST_CODE_STORAGE_WRITE);

    }

    public void requestLocationFine()
    {
        requestPermissions(new String[]{Manifest.permission.ACCESS_FINE_LOCATION},
                REQUEST_CODE_LOCATION_FINE);
    }

    public void requestLocationCoarse()
    {
        requestPermissions(new String[]{Manifest.permission.ACCESS_COARSE_LOCATION},
                REQUEST_CODE_LOCATION_COARSE);
    }

    @Override
    public void onRequestPermissionsResult(int requestCode, String[] permissions, int[] grantResults) {
        switch (requestCode) {
            case REQUEST_CODE_CAMERA:
                if (grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                    UnityPlayer.UnitySendMessage(gameObjectName, "PermissionCallback", "Granted");
                } else {
                    UnityPlayer.UnitySendMessage(gameObjectName, "PermissionCallback", "Denied");
                }
                break;
            case REQUEST_CODE_CONTACTS_READ:
                if (grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                    UnityPlayer.UnitySendMessage(gameObjectName, "PermissionCallback", "Granted");
                } else {
                    UnityPlayer.UnitySendMessage(gameObjectName, "PermissionCallback", "Denied");
                }
                break;
            case REQUEST_CODE_CONTACTS_WRITE:
                if (grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                    UnityPlayer.UnitySendMessage(gameObjectName, "PermissionCallback", "Granted");
                } else {
                    UnityPlayer.UnitySendMessage(gameObjectName, "PermissionCallback", "Denied");
                }
                break;
            case REQUEST_CODE_STORAGE_READ:
                if (grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                    UnityPlayer.UnitySendMessage(gameObjectName, "PermissionCallback", "Granted");
                } else {
                    UnityPlayer.UnitySendMessage(gameObjectName, "PermissionCallback", "Denied");
                }
                break;
            case REQUEST_CODE_LOCATION_FINE:
                if (grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                    UnityPlayer.UnitySendMessage(gameObjectName, "PermissionCallback", "Granted");
                } else {
                    UnityPlayer.UnitySendMessage(gameObjectName, "PermissionCallback", "Denied");
                }
                break;
            case REQUEST_CODE_LOCATION_COARSE:
                if (grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                    UnityPlayer.UnitySendMessage(gameObjectName, "PermissionCallback", "Granted");
                } else {
                    UnityPlayer.UnitySendMessage(gameObjectName, "PermissionCallback", "Denied");
                }
                break;
            default:
                super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
