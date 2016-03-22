using UnityEngine;
using System.Collections;

using LitJson;

public class ConfigFileReader
{
    private static string configFileDir;

    static public JsonData ReadConfig(string configFileName)
    {
        configFileDir = Application.streamingAssetsPath + "/Configs/";
#if UNITY_STANDALONE
        return LoadConfigFromDisk(configFileName);
#elif UNITY_ANDROID
        return LoadConfigFromWWW(configFileName);
#endif
    }

    static JsonData LoadConfigFromDisk(string configFileName)
    {
        string configFilePath = System.IO.Path.Combine(configFileDir, configFileName + ".json");
        if (System.IO.File.Exists(configFilePath))
        {
            return JsonMapper.ToObject(System.IO.File.ReadAllText(configFilePath));
        }
        else
        {
            Debug.LogError("The config " + configFileName + " is load failed");
            return null;
        }
    }

    static JsonData LoadConfigFromWWW(string configFileName)
    {
        float time = Time.realtimeSinceStartup;
        string configFilePath = System.IO.Path.Combine(configFileDir, configFileName + ".json");
        using (WWW www = new WWW(configFilePath))
        {
            while (!www.isDone)
            {
                if (!string.IsNullOrEmpty(www.error))
                {
                    Debug.LogError("The config " + configFileName +
                        " is load failed,beacuse of " + www.error);
                    return null;
                }
                if (Time.realtimeSinceStartup - time >= 4f)
                {
                    Debug.LogError("The config " + configFileName +
                        " is load failed,because of overtime");
                    return null;
                }
            }
            return JsonMapper.ToObject(www.text);
        }
    }
}
