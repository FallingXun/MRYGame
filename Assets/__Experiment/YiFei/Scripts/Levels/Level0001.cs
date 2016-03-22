using UnityEngine;
using System.Collections;

public class Level0001 : MonoBehaviour
{
    public GameObject[] walls;
    public GameObject[] enemySpawnPoints;

    private int mActiveWallIdx;

    void Start()
    {
        mActiveWallIdx = Random.Range(0, 4);
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].SetActive(false);
        }
        walls[mActiveWallIdx].SetActive(true);

        StartStory();
    }

    void StartStory()
    {
        InputManager.Instance.LockInput();
        DialogManager.Instance.onStoryFinish += OnReleaseEnemies;
        DialogManager.Instance.InitStoryConfig(0);
        DialogManager.Instance.GotoNextSection();
    }

    void OnReleaseEnemies()
    {
        for (int i = 0; i < 10; i++)
        {
            int randomSpawnIdx = Random.Range(0, enemySpawnPoints.Length);
            if (randomSpawnIdx != mActiveWallIdx)
            {
                Transform trans = enemySpawnPoints[randomSpawnIdx].transform;
                Vector3 randomPos = new Vector3(trans.position.x + Random.Range(0f, 1f),
                    trans.position.y + Random.Range(0f, 1f), 0f);
                EnemyManager.Instance.SpawnEnemy("Enemy_RockMan", randomPos, trans.rotation);
            }
        }

        InputManager.Instance.UnlockInput();
    }
}
