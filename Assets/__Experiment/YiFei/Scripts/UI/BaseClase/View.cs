using UnityEngine;
using System.Collections;

public class View<T> : Singleton<T> where T : View<T>
{
    protected bool isFirstShow = true;

    void Awake()
    {
        InitData();
    }

    protected virtual void InitData() { }
    public virtual void Show()
    {
        gameObject.SetActive(true);
        isFirstShow = false;
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
