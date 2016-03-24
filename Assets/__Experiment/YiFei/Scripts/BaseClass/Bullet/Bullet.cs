using UnityEngine;
using System.Collections;

namespace MRYGame
{
    public class Bullet : Unit
    {
        void Awake()
        {
            Destroy(gameObject, 5f);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Hero")
            {
                Hero hero = collision.gameObject.GetComponent<Hero>();
                hero.hp -= atk;

                if (hero.hp <= 0)
                {
                    Destroy(hero.gameObject);
                }
                Destroy(gameObject);
            }
        }
    }
}
