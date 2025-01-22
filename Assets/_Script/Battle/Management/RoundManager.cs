using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    /*
        流程：
        进入战斗
        读入数据
            单位回合
                dot结算
                选择技能
                结算阶段
                时间推进
        战斗结束
        战斗结算

     */

    public BattleData BattleDataNow;
    public BattlerSoTest BattlerSo;
    public SkillDotSo SdSo;
    [ReadOnly]
    public bool IsPlayerTurn;
    [LabelText("回合制时间"), ReadOnly]
    public int time;

    // Start is called before the first frame update
    void Start()
    {
        TurnCheck();
        BattleStartInit();
        LoadSkill();
    }

    // Update is called once per frame
    void Update()
    {
        TurnCheck();
    }

    /// <summary>
    /// 初始化战场
    /// </summary>
    private void BattleStartInit()
    {
        BattleDataNow.AllBtls = new(BattlerSo.GameBattler);

    }

    /// <summary>
    /// 回合检查，检查是否到敌人回合
    /// </summary>
    private void TurnCheck()
    {
        foreach (var item in BattleDataNow.AllBtls)
        {
            if (item.type == BattlerType.enemy && item.ActionTimeOfEnemy == 0)
            {
                IsPlayerTurn = false;
                return;
            }

            IsPlayerTurn = true;
        }
    }

    /// <summary>
    /// 处理当前回合时间
    /// </summary>
    /// <param name="value">增量</param>
    private void OnPushTimeHappen(int value)
    {
        time += value;
    }

    /// <summary>
    /// 处理玩家回合
    /// </summary>
    private void PlayerTurn()
    {
        if (IsPlayerTurn == false)
        {
            return;
        }
    }

    private void LoadSkill()
    {
        //加载技能
        foreach (var item in BattleDataNow.AllBtls.FindAll(t => t.type == BattlerType.player))
        {
            foreach (var sks in item.SkillHolds)
            {
                SkillLoader.Instance.LoadSkillsInPanel(SdSo.Skills.Find(t => t.ID == sks));
            }
        }
    }
}
