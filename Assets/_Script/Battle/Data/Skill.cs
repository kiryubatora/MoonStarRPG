using System;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill
{
    public int ID;
    public string Name;
    [LabelText("介绍"), TextArea]
    public string Description;
    [LabelText("图标")]
    public Sprite Icon;
    [LabelText("生效类型")]
    public BattlerType TargetType = BattlerType.enemy;
    [LabelText("伤害公式")]
    public string HurtLaw;
    [LabelText("直接伤害")]
    public float DirectDamage = 10;
    [LabelText("额外暴击率")]
    public float CriEx = 0;
    [LabelText("buff携带")]
    public List<DotCondition> Dots = new();
    [LabelText("治疗量")]
    public float Heal;
    [LabelText("治疗公式")]
    public string HealLaw;
    [LabelText("花费类型")]
    public SkillCostType CostType;
    [LabelText("花费")]
    public float Cost;

    [LabelText("特殊词条")]
    public SpecialCondition SpCondition = SpecialCondition.无;

    [LabelText("无视控制类型")]
    public ControlType AvoidType;
    // [LabelText("技能强度")]
    // public int Power;
}
public enum SkillCostType
{
    MP, SP, HP
}

public enum SpecialCondition
{
    无 = 0, 玩家濒死 = 1
}

[System.Serializable]
public class DotCondition
{
    public int ID;
    [LabelText("条件公式(同时满足时释放)")]
    public List<string> Law;
}