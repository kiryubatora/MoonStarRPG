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
        GetComponentInChildren<MeshRenderer>().material = new Material(GetComponentInChildren<MeshRenderer>().material);
        GetComponentInChildren<MeshRenderer>().material.mainTexture = Self.Pic.texture;
    }
}
