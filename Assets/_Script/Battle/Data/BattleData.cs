using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BattleData
{
    [LabelText("总时间限制")]
    public float TimeMax;

    [LabelText("经过时间")]
    public float CurrentTime;

    [LabelText("当前回合行动者")]
    public RoundType CurrentRound = RoundType.empty;

    [LabelText("当前战斗种类")]
    public BattleInitType InitType = BattleInitType.normal;

    [LabelText("战斗人员")]
    public List<Battler> AllBtls = new();

    public Battler CurrentBattler;
    public Battler NextBattler;
}

public enum RoundType
{
    empty, enemy, self
}

public enum BattleInitType
{
    normal, positive, negative
  //普通    我方优    敌方优
}