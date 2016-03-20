using UnityEngine;
using System.Collections;

public class SoundManager : Manager<SoundManager>
{
    public override void Init()
    {
        Debug.Log("Initialize SoundManager");
    }

    public override void Release()
    {
        Debug.Log("Release SoundManager");
    }
}
