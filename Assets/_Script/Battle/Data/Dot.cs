using System;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Dot
{
    public int ID;
    public string Name;
    [TextArea]
    public string Description;
    [LabelText("治疗量/回合")]
    public float Heal;
    [LabelText("伤害量/回合")]
    public float Damage;

    [LabelText("伤害公式")]
    public string LawOfDamage;
    [LabelText("治疗公式")]
    public string LawOfHeal;
    
    [LabelText("控制类型")]
    public ControlType controlType;
    [LabelText("持续回合(-1=无限)")]
    public int Last = 1;

    [LabelText("可以被解除")]
    public bool CanBeSolve = true;
    
    [ShowIf("@CanBeSolve == true"), LabelText("战斗后接触")]
    public bool CanBeSolveAfterBattle = true;
    
    [LabelText("解除机会"), Range(0, 1f)]
    public float RateOfSolveEveryRound = 0.05f;
    [LabelText("解除机会增长"), Range(0, 1f)]
    public float RateOfSolveIncri = 0.05f;

    [LabelText("无视控制类型")]
    public ControlType AvoidType;

    [LabelText("发送者")]
    public Battler Sender;

    [LabelText("接受者")]
    public Battler Getter;

    // [LabelText("强度")]
    // public int Power;

    //[Space(15)]
    //[LabelText("祛除率")]
    //[InfoBox("被解控技能解除的基础概率")]
    //public float SolveRate;
    //[Space(15)]
    //[LabelText("强度")]
    //[InfoBox("如果技能强度低于这个强度，每低于1，祛除dot概率减少0.065，反之增加0.065")]
    //public int Power;
}
[Flags]
public enum ControlType
{
    无 = 0, 眩晕=1, 致盲=2, 沉默=4, 混乱=8, 嘲讽=16
}