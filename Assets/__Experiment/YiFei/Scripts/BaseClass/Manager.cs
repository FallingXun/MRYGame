using UnityEngine;
using System.Collections;

public class Manager<T> : Singleton<T> where T : Manager<T>
{
    public virtual void Init() { }
    public virtual void Release() { }
}
