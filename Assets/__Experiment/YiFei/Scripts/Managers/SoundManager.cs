using UnityEngine;
using System.Collections;

namespace MRYGame
{
    public class SoundManager : Manager<SoundManager>
    {
        public override void Init()
        {
            Debug.Log("Initialize SoundManager");
        }

        public override void Release()
        {
            Debug.Log("Release SoundManager");
        }
    }
}
