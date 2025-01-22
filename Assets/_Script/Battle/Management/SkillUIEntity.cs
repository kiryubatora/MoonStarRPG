using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class SkillUIEntity : MonoBehaviour
{
    [ReadOnly] public Skill Sk;
    public Image Icon;
    public Text names;
    
    public Skill Self
    {
        get { return Sk; }
        set { Sk = value; Init(); }
    }

    private void Init()
    {
        Icon.sprite = Sk.Icon;
        names.text = Sk.Name;
    }
}