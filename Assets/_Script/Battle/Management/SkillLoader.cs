using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
/// 加载技能UI
/// </summary>
public class SkillLoader : MonoBehaviour
{
    public static SkillLoader Instance;
    [LabelText("技能UI预制体"), AssetsOnly]
    public GameObject Prefab;
    [LabelText("技能父物体"), SceneObjectsOnly]
    public RectTransform SkillPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadSkillsInPanel(Skill sk)
    {
        //生成与加载
        var go = Instantiate(Prefab, SkillPanel.transform);
        var sue = go.GetComponent<SkillUIEntity>();
        sue.Self = sk;
    }
}
