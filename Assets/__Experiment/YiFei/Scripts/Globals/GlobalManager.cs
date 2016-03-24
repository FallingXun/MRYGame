using UnityEngine;
using System.Collections;

namespace MRYGame
{
    public class GlobalManager : MonoBehaviour
    {
        /// <summary>
        /// 按照固定顺序初始化管理器
        /// </summary>
        void Awake()
        {
            InputManager.Instance.Init();
            LevelManager.Instance.Init();
            SoundManager.Instance.Init();
            EnemyManager.Instance.Init();
            DialogManager.Instance.Init();
        }

        /// <summary>
        /// 按照反向顺序释放管理器
        /// </summary>
        void OnDestroy()
        {
            DialogManager.Instance.Release();
            SoundManager.Instance.Release();
            EnemyManager.Instance.Release();
            LevelManager.Instance.Release();
            InputManager.Instance.Release();
        }
    }
}
