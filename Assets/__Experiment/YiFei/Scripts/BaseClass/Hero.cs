using UnityEngine;
using System.Collections;

public class Hero : Unit
{
    void Start()
    {
        InputManager.Instance.SetInputState(this, InputManager.EInputType.Keyboard);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "EnemySkill")
        {
            if (--hp <= 0)
            {
                Destroy(this.gameObject);
            }
            Destroy(collider.gameObject);
        }
    }
}
