using UnityEngine;
using System.Collections;

public class Enemy_RockMan : Enemy
{
    public GameObject skillPrefab;

    void Start()
    {
        InvokeRepeating("Skill", 0f, 5f);
    }

    void FireSkill()
    {
        GameObject go = Instantiate(skillPrefab, transform.position + Vector3.up,
            transform.rotation) as GameObject;
        Destroy(go, 5f);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "EnemySkill"
            || collider.gameObject.tag == "HeroSkill")
        {
            if (--hp <= 0)
            {
                Destroy(this.gameObject);
            }
            Destroy(collider.gameObject);
        }
    }
}
