package com.seanix.sean.plugin;

// Features.
import android.Manifest;
import android.annotation.TargetApi;
import android.app.Fragment;
import android.content.pm.PackageManager;
import android.os.Bundle;

// Unity.
import com.unity3d.player.UnityPlayer;

// Debug.
import android.widget.Toast;

/**
 * Created by Sean on 3/28/2017.
 */

@TargetApi(23)
public class PermissionGranter extends Fragment {

    public static final String TAG = "Sean_Alert";

    public static PermissionGranter instance;

    final private int REQUEST_CODE_CAMERA = 1;

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

    @Override
    public void onRequestPermissionsResult(int requestCode, String[] permissions, int[] grantResults) {
        switch (requestCode) {
            case REQUEST_CODE_CAMERA:
                if (grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                    // Permission Granted
                    Toast.makeText(getActivity(), "CAMERA Permission Granted", Toast.LENGTH_SHORT)
                            .show();
                } else {
                    // Permission Denied
                    Toast.makeText(getActivity(), "CAMERA Permission Denied", Toast.LENGTH_SHORT)
                            .show();
                }
                break;
            default:
                super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
