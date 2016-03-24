using UnityEngine;
using System.Collections;

namespace MRYGame
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        protected static T instance;
        static public T Instance
        {
            get
            {
                if (instance == null)
                {
                    T[] t = GameObject.FindObjectsOfType<T>();
                    if (t.Length > 1)
                    {
                        Debug.LogError("The Scene has multiple singleton,now choose first object");
                    }
                    instance = t[0];
                }
                return instance;
            }
        }
    }
}
