using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BattleData
{
    /// <summary>
    /// 总时间限制
    /// </summary>
    [LabelText("总时间限制")]
    public float TimeMax;

    /// <summary>
    /// 经过时间
    /// </summary>
    [LabelText("经过时间"), DisableInEditorMode]
    public float CurrentTime;

    /// <summary>
    /// 当前回合行动者
    /// </summary>
    [LabelText("当前回合行动者")]
    public RoundType CurrentRound = RoundType.empty;

    /// <summary>
    /// 当前战斗种类
    /// </summary>
    [LabelText("当前战斗种类")]
    public BattleInitType InitType = BattleInitType.normal;

    /// <summary>
    /// 战斗人员
    /// </summary>
    [LabelText("战斗人员"), DisableInEditorMode]
    public List<Battler> AllBtls = new();

    public BattleData(float timeMax, float currentTime, RoundType currentRound, BattleInitType initType, Battler currentBattler, Battler nextBattler)
    {
        TimeMax = timeMax;
        CurrentTime = currentTime;
        CurrentRound = currentRound;
        InitType = initType;
    }
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