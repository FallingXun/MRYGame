using UnityEngine;
using System.Collections;

namespace MRYGame
{
    public class LevelManager : Manager<LevelManager>
    {
        public int levelId;
        public int levelName;

        public override void Init()
        {
            Debug.Log("Initialize LevelManager");
        }

        public override void Release()
        {
            Debug.Log("Release LevelManager");
        }
    }
}
