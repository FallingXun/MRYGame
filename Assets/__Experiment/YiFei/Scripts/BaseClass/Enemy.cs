using UnityEngine;
using System.Collections;

public class Enemy : Unit
{
    private Rigidbody2D mRigid2d;

    void Awake()
    {
        mRigid2d = GetComponent<Rigidbody2D>();
        if (mRigid2d == null)
            Debug.LogError("The enemy's rigidbody2d is not exist");
    }
}
