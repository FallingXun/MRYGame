using UnityEngine;
using System.Collections;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    protected static T mInstance;
    static public T Instance
    {
        get
        {
            if (mInstance == null)
            {
                T[] t = GameObject.FindObjectsOfType<T>();
                if (t.Length > 1)
                {
                    Debug.LogError("The Scene has multiple singleton,now choose first object");
                }
                mInstance = t[0];
            }
            return mInstance;
        }
    }
}
