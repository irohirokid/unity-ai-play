using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic
{
    public Action CurrentAction;

    DataRepository data;

    public void Setup(DataRepository _data)
    {
        data = _data;
    }

    public IEnumerator Behaviour()
    {
        while (true)
        {
            makeDecision();
            yield return new WaitUntil(needDecision);
        }
    }

    void makeDecision()
    {
        data.Enemy.TargetPoint = data.Enemy.Position + (data.Player.Position - data.Enemy.Position) * 1.5f;
        CurrentAction = () => data.Enemy.Chase();
    }

    bool needDecision()
    {
        return data.Enemy.didFinishAction();
    }
}
