using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Battler
{
    public string Name;
    [LabelText("介绍"), TextArea]
    public string Description;
    [LabelText("头像")]
    public Sprite Avatar;
    [LabelText("立绘图片")]
    public Sprite Pic;
    [LabelText("生命值")]
    public float Hp;
    [LabelText("魔力值")]
    public float Mp;
    [LabelText("攻击力")]
    public float Atk;
    [LabelText("咒文")]
    public float Spell;
    [LabelText("治疗")]
    public float HealStrength;
    [LabelText("防御力")]
    public float Def;
    [LabelText("暴击率"), Range(0, 1)]
    public float Crit;
    [LabelText("希望"), Range(0, 1)]
    public float Hope;
    [LabelText("速度")]
    public float Speed;
    [LabelText("血量")]
    public float Sp;
    [LabelText("减益抵抗"), Range(0, 1)]
    public float DebuffDef;
    [LabelText("痛苦抵抗"), Range(0, 1)]
    public float PainDef;
    [LabelText("限制抵抗"), Range(0, 1)]
    public float LimitDef;
    [LabelText("持有技能")]
    public List<int> SkillHolds;
    [LabelText("持有buff")]
    public List<int> DotsHolds;
    [LabelText("战斗人员类型")]
    public BattlerType type = BattlerType.player;

    public float FakeHp = 0f;

    [LabelText("作为敌人时，什么时候行动"), ShowIf("@type == BattlerType.enemy")]
    public int ActionTimeOfEnemy = 3;
}
public enum BattlerType
{
    player, enemy, other
}