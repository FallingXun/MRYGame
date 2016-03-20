using UnityEngine;
using System.Collections;

public class EnemyManager : Manager<EnemyManager>
{
    public override void Init()
    {
        Debug.Log("Initialize EnemyManager");
    }

    public override void Release()
    {
        Debug.Log("Release EnemyManager");
    }
}
