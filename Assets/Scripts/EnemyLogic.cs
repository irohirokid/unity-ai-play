using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic
{
    EnemyData data;
    public Action CurrentAction;

    public void Setup(EnemyData _data)
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
        World.Enemy.TargetPoint = World.Enemy.Position + (World.Player.Position - World.Enemy.Position) * 1.5f;
        CurrentAction = () => World.Enemy.Chase();
    }

    bool needDecision()
    {
        return World.Enemy.didFinishAction();
    }
}
