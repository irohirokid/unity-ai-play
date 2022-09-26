using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : IIntelligent
{
    DataRepository data;

    public void Setup(DataRepository _data)
    {
        data = _data;
    }

    public void DoAction()
    {
        data.Enemy.CurrentAction();
    }

    public void makeDecision()
    {
        data.Enemy.TargetPoint = data.Enemy.Position.Value + (data.Player.Position.Value - data.Enemy.Position.Value) * 1.5f;
        data.Enemy.CurrentAction = data.Enemy.Chase;
    }

    public bool needDecision()
    {
        return data.Enemy.didFinishAction();
    }
}
