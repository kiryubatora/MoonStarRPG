using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    /*
        流程：
        进入战斗
        读入数据
        计算顺序
            单位回合
                dot结算
                选择技能
                结算阶段
                时间推进
        战斗结束
        战斗结算

     */

    public BattleData BattleDataNow;

    // Start is called before the first frame update
    void Start()
    {
        BattleDataNow = new();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BattleStartInit()
    {
        
    }

    private void BattlerSort()
    {
        
    }
}
