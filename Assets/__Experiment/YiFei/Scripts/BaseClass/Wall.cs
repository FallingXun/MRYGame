using UnityEngine;
using System.Collections;

namespace MRYGame
{
    public class Wall : Unit
    {
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
}
