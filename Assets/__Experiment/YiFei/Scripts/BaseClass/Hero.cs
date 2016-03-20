using UnityEngine;
using System.Collections;

public class Hero : Unit
{
    void Start()
    {
        InputManager.Instance.SetInputState(this, InputManager.EInputType.Keyboard);
    }
}
