using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlerEntity : MonoBehaviour
{
    private Battler Self;

    public Battler BattlerUnit
    {
        get { return Self; }
        set
        {
            Self = value;
            Init();
        }
    }

    public void Init()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = Self.Pic;
    }
}
