using UnityEngine;
using System.Collections;

namespace MRYGame
{
    public class Hero : Actor
    {
        void Start()
        {
            InputManager.Instance.SetInputState(this, InputManager.EInputType.Keyboard);
        }
    }
}
