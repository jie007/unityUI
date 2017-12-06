using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PathHelper
{
    static string Z_MANIFEST = ".manifest";
    static string Z_META = ".meta";
    static string Z_MAT = ".mat";
    static public bool FastEndsWith(string sPattern, string sWhat)
    {
        int i, j;
        for (i = sPattern.Length - 1, j = sWhat.Length - 1; i >= 0 && j >= 0; i--, j--)
        {
            if (sPattern[i] != sWhat[j]) return false;
        }
        return j == -1;
    }
    static public bool IsGoodBundleName(string sName)
    {
        return !(FastEndsWith(sName, Z_MANIFEST) || FastEndsWith(sName, Z_META) || FastEndsWith(sName, Z_MAT));
    }
    static private string RWRoot = "";
    static public string GetReadAndWriteRoot()
    {
        if (RWRoot.Equals(""))
        {
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.WindowsPlayer:
                    RWRoot = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf("/")) + "/AB_WIN/";
                    break;
                case RuntimePlatform.OSXEditor:
                case RuntimePlatform.OSXPlayer:
                    RWRoot = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf("/")) + "/AB_IOS/";
                    break;
                case RuntimePlatform.Android:
                    RWRoot = Application.persistentDataPath + "/AB_AND/";
                    break;
                case RuntimePlatform.IPhonePlayer:
                    RWRoot = Application.persistentDataPath + "/AB_IOS/";
                    break;
                default:
                    RWRoot = Application.persistentDataPath;
                    break;
            }
        }
        return RWRoot;
    }

    private static string GetAndroidExternalStoragePath()
    {
        string path = "";
        try
        {
            AndroidJavaClass jc = new AndroidJavaClass("android.os.Environment");
            path = jc.CallStatic<AndroidJavaObject>("getExternalStorageDirectory").Call<string>("getAbsolutePath");
            return path;
        }
        catch (Exception e)
        {
            return e.Message;
        }
        return path;
    }

    private static int GetVersionCode()
    {
        AndroidJavaClass contextCls = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject context = contextCls.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject packageMngr = context.Call<AndroidJavaObject>("getPackageManager");
        string packageName = context.Call<string>("getPackageName");
        AndroidJavaObject packageInfo = packageMngr.Call<AndroidJavaObject>("getPackageInfo", packageName, 0);
        return packageInfo.Get<int>("versionCode");
    }

    static private string OBBPath = "";
    static public string GetObbFilePath()
    {
        if (OBBPath.Length == 0)
        {
            //WWW tmp;
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.WindowsPlayer:
                    OBBPath = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf("/")) + "/main.obb";
                    break;
                case RuntimePlatform.OSXEditor:
                case RuntimePlatform.OSXPlayer:
                    OBBPath = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf("/")) + "/main.obb";
                    break;
                case RuntimePlatform.Android:
                    OBBPath = string.Format("{0}/Android/obb/{1}/main.{2}.{1}.obb",
                        GetAndroidExternalStoragePath(),
                        Application.buildGUID,
                        GetVersionCode()
                        );
                    //tmp = new WWW("http://42.121.1.43/?obb=" + OBBPath);
                    break;
                //TODO: android
                default:
                    return "noobb";
            }
        }
        return OBBPath;
    }


    static public string GetStreamingAssetRoot()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.WindowsPlayer:
                return Application.streamingAssetsPath + "/AB_WIN/";
            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.OSXPlayer:
                return Application.streamingAssetsPath + "/AB_IOS/";
            case RuntimePlatform.Android:
                return Application.streamingAssetsPath + "/AB_AND/";
            case RuntimePlatform.IPhonePlayer:
                return Application.streamingAssetsPath + "/AB_IOS/";
            default:
                return Application.streamingAssetsPath;
        }
    }
}
