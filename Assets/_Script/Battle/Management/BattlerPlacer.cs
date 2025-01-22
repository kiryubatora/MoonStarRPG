using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

public class BattlerPlacer : MonoBehaviour
{
    [LabelText("预制体"), AssetsOnly] public GameObject UnitPrefab;

    [InfoBox("0:中心，1：靠前，2：靠后，3：靠前，4：靠后")] [LabelText("敌军生成点")]
    public List<Transform> EnemyPoints;

    [LabelText("玩家生成点")] public List<Transform> PlayerPoints;
    [LabelText("朝向控制的父物体")] public Transform FatherObj;
    [LabelText("玩家队伍"), ReadOnly] public List<Battler> PlayerUnits = new();
    [LabelText("敌人队伍"), ReadOnly] public List<Battler> EnemyUnits = new();

    // Start is called before the first frame update
    void Start()
    {
        PlayerUnits = new();
        EnemyUnits = new();
        foreach (var item in RoundManager.Instance.BattleDataNow.AllBtls)
        {
            if (item.type == BattlerType.player)
            {
                PlayerUnits.Add(item);
            }

            if (item.type == BattlerType.enemy)
            {
                EnemyUnits.Add(item);
            }
        }

        for (int i = 0; i < PlayerUnits.Count; i++)
        {
            GeneBattlerInPoint(i, PlayerUnits[i], PlayerPoints);
        }
        for (int i = 0; i < EnemyUnits.Count; i++)
        {
            GeneBattlerInPoint(i, EnemyUnits[i], EnemyPoints);
        }
    }

    private void GeneBattlerInPoint(int point, Battler tg, List<Transform> target)
    {
        var go = Instantiate(UnitPrefab, target[point].position, quaternion.identity);
        go.GetComponent<BattlerEntity>().BattlerUnit = tg;
        go.transform.SetParent(FatherObj);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if (PlayerPoints.Count > 0)
        {
            foreach (var item in PlayerPoints)
            {
                if (item == null)
                {
                    continue;
                }

                Gizmos.DrawSphere(item.position, 1f);
            }
        }

        Gizmos.color = Color.red;
        if (EnemyPoints.Count > 0)
        {
            foreach (var item in EnemyPoints)
            {
                if (item == null)
                {
                    continue;
                }

                Gizmos.DrawSphere(item.position, 1f);
            }
        }
    }
}