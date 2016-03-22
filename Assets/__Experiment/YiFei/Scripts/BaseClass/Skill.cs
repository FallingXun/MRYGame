using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour
{
    private Rigidbody2D mRigid2d;

    void Awake()
    {
        mRigid2d = GetComponent<Rigidbody2D>();
        if (mRigid2d == null)
            Debug.LogError("The enemy's rigidbody2d is not exist");
    }

    void Start()
    {
        mRigid2d.AddForce(new Vector2(100f, 200f), ForceMode2D.Force);
    }
}
