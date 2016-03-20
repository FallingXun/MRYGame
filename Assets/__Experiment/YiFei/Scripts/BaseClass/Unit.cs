using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public enum EUnitProperty
    {
        HP,
        MP,
        Speed
    }

    public float hp;
    public float mp;
    public float walkSpeed;
    public float spinSpeed;
}
