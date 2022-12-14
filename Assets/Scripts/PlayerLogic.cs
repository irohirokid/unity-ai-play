using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : IIntelligent
{
    DataRepository data;
    public void Setup(DataRepository _data)
    {
        data = _data;
    }

    public void OnClick(Vector3 point)
    {
        data.Player.Destination = point + new Vector3(0, 0.5f, 0);
    }

    public void DoAction()
    {
        data.Player.CurrentAction();
    }

    public void makeDecision()
    {
        data.Player.CurrentAction = data.Player.Walk;
    }

    public bool needDecision()
    {
        return !data.Player.HasWayToGo();
    }
}
