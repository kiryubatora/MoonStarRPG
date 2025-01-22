using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Battler 1", menuName = "Battler SO")]
public class BattlerSoTest : ScriptableObject
{
    public List<Battler> GameBattler = new();
}
