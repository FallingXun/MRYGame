using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MRYGame
{
    public class EnemyManager : Manager<EnemyManager>
    {
        public GameObject enemyCollection;
        private List<Enemy> enemyList = new List<Enemy>();

        public override void Init()
        {
            Debug.Log("Initialize EnemyManager");
        }

        public override void Release()
        {
            Debug.Log("Release EnemyManager");
        }

        public void SpawnEnemy(string enemyName, Vector3 position, Quaternion rotation)
        {
            GameObject prefab = Resources.Load<GameObject>("Enemies/" + enemyName);
            if (prefab != null)
            {
                GameObject go = Instantiate(prefab, position, rotation) as GameObject;
                go.transform.SetParent(enemyCollection.transform);
                Enemy enemy = go.GetComponent<Enemy>();
                enemyList.Add(enemy);
            }
            else
            {
                Debug.LogError("The prefab " + enemyName + " is load failed");
            }
        }
    }
}
