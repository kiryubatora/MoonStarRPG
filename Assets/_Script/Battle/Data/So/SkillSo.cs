using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "SkillDot 1", menuName = "SkillDot SO")]
public class SkillDotSo : ScriptableObject
{
    [ListDrawerSettings(ShowIndexLabels = true, ListElementLabelName = "Name")]
    public List<Skill> Skills = new();
    [Space(30)]
    [ListDrawerSettings(ShowIndexLabels = true, ListElementLabelName = "Name")]
    public List<Dot> Dots = new();
}

